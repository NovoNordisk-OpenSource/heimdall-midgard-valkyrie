namespace Heimdall.Midgard.Valkyrie.Infrastructure.IntegrationTest.Fixtures;

public class ServiceProviderFixture : IDisposable
{
    private readonly ConfigurationFixture _configFixture = new ConfigurationFixture();

    public IServiceProvider Provider { get; init; }

    public ServiceProviderFixture()
    {
        var services = new ServiceCollection();

        services.AddInfrastructure(_configFixture.Configuration);

        Provider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        _configFixture.Dispose();
    }
}
