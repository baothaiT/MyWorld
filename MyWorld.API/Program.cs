using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyWorld.API.Configs;
using MyWorld.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyWorldDb")));
builder.Services.AddHostedService<DbMigrationJob>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
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
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWorld API V1");
        x.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
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
