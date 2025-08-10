using System;

namespace MyWorld.Worker.Configs;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }
}
