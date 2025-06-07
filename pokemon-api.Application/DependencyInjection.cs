using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using pokemon_api.Application.Common.Behaviour;

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
        
        
        //IPipelineBehavior<,> is a generic interface that defines a step in the request/response pipeline.
        //ValidationBehaviour<,> is your class that implements this interface — it runs before the request hits the handler.
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>)
        );
        
        //This registers all FluentValidation validators in the current project (assembly).
        //scans your assembly for any classes that implement IValidator<T>.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}