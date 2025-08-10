using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MyWorld.MasterDataAPI.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
builder.Services.ConfigureCors();
var app = builder.Build();

app.UseCustomApplication();
app.Run();

