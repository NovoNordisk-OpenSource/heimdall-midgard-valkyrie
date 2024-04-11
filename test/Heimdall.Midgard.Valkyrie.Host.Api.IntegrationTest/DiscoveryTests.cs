namespace Heimdall.Midgard.Valkyrie.Host.Api.IntegrationTest;

public class DiscoveryTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Theory]
    [InlineData("/discovery/v1/openapi/schema.json")]
    [InlineData("/discovery/v1/asyncapi/schema.json")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Contains("application/json", response.Content.Headers.ContentType.ToString());
    }
}