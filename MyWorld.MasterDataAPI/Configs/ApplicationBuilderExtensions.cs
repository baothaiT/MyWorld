using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System;

namespace MyWorld.MasterDataAPI.Configs;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomApplication(this WebApplication  app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterData API V1");
                x.RoutePrefix = string.Empty;
            });
        }
        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseCors();
        app.MapHealthChecks("/health");
        app.UseRouting()
            .UseEndpoints(config =>
            {
                config.MapHealthChecks("healthz", new HealthCheckOptions
                {
                    // Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                // config.MapHealthChecksUI();
                // config.MapDefaultControllerRoute();
            });
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}
