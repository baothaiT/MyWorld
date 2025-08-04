using System;
using Template.Integration.Tests.Common.Configurations;

namespace Template.Integration.Tests.Scenarios.Vocabulary;

public class VocabularyFixture: IClassFixture<TestServer>
{
    protected TestServer _webapplication;
    public VocabularyFixture(TestServer webapplication)
    {
        _webapplication = webapplication;
    }
}
