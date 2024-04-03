namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework;

/// <summary>
///     Factory class for creating the application context during design time.
/// </summary>
public sealed class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    /// <summary>
    ///     Creates a new instance of the application context for design time.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <returns>The created application context.</returns>
    public ApplicationContext CreateDbContext(string[] args)
    {
        var host = Path.Exists("/.dockerenv") ? "database" : "localhost";
        var connection = new NpgsqlConnection($"User ID=postgres;Password=local;Host={host};Port=5432;Database=postgres");

        connection.Open();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(connection);

        return new ApplicationContext(optionsBuilder.Options);
    }
}