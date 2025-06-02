using Microsoft.Extensions.DependencyInjection;
using pokemon_api.Application.Common.Interfaces.Authentication;
using pokemon_api.Application.Services.Authentication;
using pokemon_api.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;

namespace pokemon_api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}