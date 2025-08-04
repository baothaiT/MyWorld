using MyWorld.AppHost.Common.Contants.Enums;
using MyWorld.Integration.Tests.Common.Configurations;
using MyWorld.Integration.Tests.Collections;

namespace MyWorld.Integration.Tests.Scenarios.Vocabulary;

[Collection(nameof(VocabularyTestCollection))]
public class VocabularyTest : VocabularyFixture
{
    public VocabularyTest(TestServer webapplication) : base(webapplication)
    {
    }

    [Theory]
    [InlineData("api/Vocabulary")]
    public async Task GetVocabulary_ReturnsOkStatusCode(string url)
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        var httpClient = _webapplication.Client;
        await _webapplication.App.ResourceNotifications.WaitForResourceHealthyAsync(nameof(ServiceNameEnum.MyWorldAPI), cts.Token);

        // Act
        var response = await httpClient.GetAsync(url, cts.Token);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/Vocabulary/Welcome")]
    [InlineData("api/Vocabulary/Goodbye")]
    [InlineData("api/Vocabulary/Error")]
    [InlineData("api/Vocabulary/Success")]
    public async Task GetVocabularyByKey_ReturnsOkStatusCode(string url)
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        var httpClient = _webapplication.Client;
        await _webapplication.App.ResourceNotifications.WaitForResourceHealthyAsync(nameof(ServiceNameEnum.MyWorldAPI), cts.Token);

        // Act
        var response = await httpClient.GetAsync(url, cts.Token);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("api/Vocabulary/NonExistentKey")]
    public async Task GetVocabularyByKey_ReturnsNotFound_WhenKeyDoesNotExist(string url)
    {
        // Arrange
        using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        var httpClient = _webapplication.Client;
        await _webapplication.App.ResourceNotifications.WaitForResourceHealthyAsync(nameof(ServiceNameEnum.MyWorldAPI), cts.Token);

        // Act
        var response = await httpClient.GetAsync(url, cts.Token);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
