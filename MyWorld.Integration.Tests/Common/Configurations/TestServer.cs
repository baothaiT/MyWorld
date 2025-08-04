using Aspire.Hosting;
using Aspire.Hosting.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWorld.AppHost.Common.Contants.Enums;
using MyWorld.ServiceDefaults.Common.Extensions;

namespace MyWorld.Integration.Tests.Common.Configurations
{
    public class TestServer : IAsyncLifetime
    {
        private IConfiguration? _configuration;
        private IDistributedApplicationTestingBuilder _appTestingBuilder;
        public DistributedApplication App;
        public HttpClient Client;
        private IServiceProvider _serviceProvider;
        private IServiceScope _serviceScope;
        public async Task InitializeAsync()
        {
            _configuration = ConfigurationExtension.GetConfigurations();
            _appTestingBuilder = await DistributedApplicationTestingBuilder.CreateAsync<Projects.MyWorld_AppHost>();
            // _appTestingBuilder = await DistributedApplicationTestingBuilder.CreateAsync<Projects.MyWorld_AppHost>
            // (
            // args: [],
            // configureBuilder: (appOptions, hostSettings) =>
            // {
            //     appOptions.DisableDashboard = false;

            //     // Configure for HTTP-only in Docker environment
            //     if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
            //     {
            //         hostSettings.Configuration["ASPNETCORE_URLS"] = "http://+:8080";
            //         hostSettings.Configuration["ASPNETCORE_ENVIRONMENT"] = "Development";
            //     }

            //     hostSettings.EnvironmentName = "Development";
            // });

            _appTestingBuilder.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler(options =>
                {
                    // Increase timeout for Docker environment
                    options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
                    options.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(2);
                    
                    // Fix circuit breaker sampling duration - must be at least double the attempt timeout
                    options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(70); // More than double of 30s
                    
                    // Optional: Adjust other circuit breaker settings for Docker environment
                    options.CircuitBreaker.FailureRatio = 0.7; // Allow more failures before opening
                    options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(10); // Shorter break duration
                });
            });
            
            App = await _appTestingBuilder.BuildAsync();
            await App.StartAsync();

            Client = App.CreateHttpClient(nameof(ServiceNameEnum.MyWorldAPI));
        }
        public async Task DisposeAsync()
        {
            await App.StopAsync();
            await App.DisposeAsync();
        }
    }
}
