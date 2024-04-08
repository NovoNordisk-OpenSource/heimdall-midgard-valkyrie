namespace Heimdall.Midgard.Valkyrie.Infrastructure.IntegrationTest.Fixtures;

public class ApplicationContextFixture : IDisposable
{
    private readonly DbContextOptions _options;
    private readonly NpgsqlConnection _connection;
    private bool _disposedValue;
    private readonly ConfigurationFixture _configFixture = new ConfigurationFixture();

    public ApplicationContextFixture()
    {
        _connection = new NpgsqlConnection(_configFixture.Configuration.GetConnectionString("ApplicationContext"));

        _connection.Open();

        _options = new DbContextOptionsBuilder().UseNpgsql(_connection).Options;
    }

    public ApplicationContext GetDbContext(IMediator mediator = default)
    {
        return new ApplicationContext(_options, mediator);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _connection.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}