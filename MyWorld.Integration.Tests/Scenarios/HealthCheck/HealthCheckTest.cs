using Aspire.Hosting.ApplicationModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyWorld.AppHost.Common.Contants.Enums;
using MyWorld.Integration.Tests.Common.Configurations;

namespace MyWorld.Integration.Tests.Scenarios.HealthCheck
{
    [CollectionDefinition(nameof(HealthCheckCollection))]
    public class HealthCheckTest : HealthCheckFixture
    {
        public HealthCheckTest(TestServer webapplication) : base(webapplication)
        {
        }

        [Theory]
        [InlineData("")]
        [InlineData("api/Health")]
        public async Task HealthCheck_ReturnsOkStatusCode(string url)
        {
            // Arrange
            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2)); // Increased timeout for Docker
            var httpClient = _webapplication.Client;
            await _webapplication.App.ResourceNotifications.WaitForResourceHealthyAsync(nameof(ServiceNameEnum.MyWorldAPI), cts.Token);

            // Act
            var response = await httpClient.GetAsync(url, cts.Token);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
