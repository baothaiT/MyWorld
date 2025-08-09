using MyWorld.Application.Interfaces;
using MyWorld.Application.Services;
using MyWorld.Domain.Repositories;
using MyWorld.Infra.Repositories;
using System;

namespace MyWorld.API.Configs;

public static class ServicesExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();

        services.AddScoped<IUserService, UserService>();
        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVocabularyRepository, VocabularyRepository>();
        return services;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        return services;
    }

    public static IServiceCollection ConfigureJob(this IServiceCollection services)
    {
        services.AddHostedService<DbMigrationJob>();
        return services;
    }

    public static IServiceCollection ConfigureDB(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyWorldDb")));
        return services;
    }
}
