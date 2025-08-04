using System;
using Template.Integration.Tests.Common.Configurations;

namespace Template.Integration.Tests.Scenarios.HealthCheck;

[CollectionDefinition(nameof(HealthCheckCollection))]
public class HealthCheckCollection : ICollectionFixture<TestServer>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
