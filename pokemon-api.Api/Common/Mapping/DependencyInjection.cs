﻿using System.Reflection;
using Mapster;
using MapsterMapper;
namespace pokemon_api.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        
        services.AddSingleton(config);
        services.AddScoped<IMapper,ServiceMapper>();
        return services;

    }
}