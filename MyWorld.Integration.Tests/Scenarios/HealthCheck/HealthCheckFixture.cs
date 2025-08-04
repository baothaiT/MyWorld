using System;
using MyWorld.Integration.Tests.Common.Configurations;

namespace MyWorld.Integration.Tests.Scenarios.HealthCheck;

public class HealthCheckFixture : IClassFixture<TestServer>
{
    protected TestServer _webapplication;
    public HealthCheckFixture(TestServer webapplication)
    {
        _webapplication = webapplication;
    }
}
