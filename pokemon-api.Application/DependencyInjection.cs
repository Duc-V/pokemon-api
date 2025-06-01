using Microsoft.Extensions.DependencyInjection;
using pokemon_api.Application.Services.Authentication;

namespace pokemon_api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}