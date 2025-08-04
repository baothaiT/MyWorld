using System;
using MyWorld.Integration.Tests.Common.Configurations;

namespace MyWorld.Integration.Tests.Scenarios.HealthCheck;

[CollectionDefinition(nameof(HealthCheckCollection))]
public class HealthCheckCollection : ICollectionFixture<TestServer>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
