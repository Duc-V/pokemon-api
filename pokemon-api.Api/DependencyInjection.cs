using Microsoft.AspNetCore.Mvc.Infrastructure;
using pokemon_api.Api.Common.Errors;
using pokemon_api.Api.Common.Mapping;

namespace pokemon_api.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {   
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>(); 
        services.AddMappings(); 
        return services;
    }
}