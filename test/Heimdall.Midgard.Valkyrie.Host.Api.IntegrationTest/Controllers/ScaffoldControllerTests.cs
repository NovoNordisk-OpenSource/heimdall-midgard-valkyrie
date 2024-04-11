using System.Net.Http;
using Heimdall.Midgard.Valkyrie.Host.Api.IntegrationTest.Fixtures;

namespace Heimdall.Midgard.Valkyrie.Host.Api.IntegrationTest;

public class ScaffoldControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ScaffoldControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetScaffoldTaskReturnsListOrEmpty()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/scaffold");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("application/json", response.Content.Headers.ContentType.ToString());
        Assert.True(content.Length > 0);
    }
}