using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace pokemon_api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {   
        // MediatR scans the current assembly where DependencyInjection class lives for
        // any handlers. This allows IMediator to be injected into controllers and services
        // to send commands and queries, with MediatR automatically dispatching them to the right handlers
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });      
        return services;
    }
}