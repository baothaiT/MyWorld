using System;
using Template.Integration.Tests.Common.Configurations;

namespace Template.Integration.Tests.Scenarios.HealthCheck;

public class HealthCheckFixture : IClassFixture<TestServer>
{
    protected TestServer _webapplication;
    public HealthCheckFixture(TestServer webapplication)
    {
        _webapplication = webapplication;
    }
}
