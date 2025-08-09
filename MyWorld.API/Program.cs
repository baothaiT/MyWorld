using MyWorld.API.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDB(builder);
builder.Services.ConfigureJob();
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCors();

var app = builder.Build();
app.UseCustomApplication();
app.Run();
