using System;
using MyWorld.Integration.Tests.Common.Configurations;

namespace MyWorld.Integration.Tests.Scenarios.Vocabulary;

public class VocabularyFixture: IClassFixture<TestServer>
{
    protected TestServer _webapplication;
    public VocabularyFixture(TestServer webapplication)
    {
        _webapplication = webapplication;
    }
}
