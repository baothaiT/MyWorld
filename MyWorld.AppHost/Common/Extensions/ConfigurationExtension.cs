using Microsoft.Extensions.Configuration;
using System;

namespace MyWorld.AppHost.Common.Extensions;

public static class ConfigurationExtension
{
    public static IConfiguration GetConfigurations()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }
}
