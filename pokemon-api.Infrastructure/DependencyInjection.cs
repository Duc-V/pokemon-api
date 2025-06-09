using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using pokemon_api.Application.Common.Interfaces.Authentication;
using pokemon_api.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pokemon_api.Application.Common.Interfaces.Persistence;
using pokemon_api.Infrastructure.Persistence;

namespace pokemon_api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAuth(configuration);      
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {   
        // JwtSettings class
        var jwtSettings = new JwtSettings();
        // bind the JwtSettings json to the JwtSettings class
        configuration.Bind(JwtSettings.Section, jwtSettings);
        //Registers the JwtSettings instance so you can inject it elsewhere (e.g. into your token generator).
        services.AddSingleton(Options.Create(jwtSettings));
        //Add Jwt Generator service
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        // This configures the app to accept only valid JWTs on incoming requests:
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))

            });
        return services;
    }
}