using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MyWorld.MasterDataAPI.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCors();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseHttpsRedirection();
// app.UseCors();
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
app.Run();

