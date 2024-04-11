namespace Heimdall.Midgard.Valkyrie.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    ///     Adds infrastructure dependencies to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the dependencies to.</param>
    /// <param name="configuration">The IConfiguration instance.</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Upstream dependencies
        services.AddApplication();
        services.AddKafka(configuration);
        services.AddSecurityPolicies();

        // Application dependencies
        services.AddApplicationContext(configuration);
        services.AddRepositories();
        services.AddStrategies();
    }

    /// <summary>
    ///     Adds the application context to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the application context to.</param>
    /// <param name="configuration">The IConfiguration instance.</param>
    private static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure EntityContextOptions
        services.Configure<EntityContextOptions>(configuration);

        // Add DbContext
        services.AddDbContext<ApplicationContext>(options =>
        {            
            var serviceProvider = services.BuildServiceProvider();
            var dbContextOptions = serviceProvider.GetService<IOptions<EntityContextOptions>>();
            var callingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var connectionString = dbContextOptions?.Value?.ConnectionStrings?.GetValue<string>(nameof(ApplicationContext));

            if (string.IsNullOrEmpty(connectionString))
                throw new ApplicationFacadeException($"Could not find connection string with entry key: {nameof(ApplicationContext)}");

            var dbOptions = options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(callingAssemblyName);
                    npgsqlOptions.MigrationsHistoryTable(callingAssemblyName + "_MigrationHistory");
                }).Options;

            using var context = new ApplicationContext(dbOptions, serviceProvider?.GetService<IMediator>());

            if (dbContextOptions?.Value?.EnableAutoMigrations == true) context.Database.Migrate();
        });

        // Add IUnitOfWork
        services.AddTransient<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationContext>());

        // Add EF Core Health Check
        services.AddHealthChecks().AddDbContextCheck<ApplicationContext>(tags: ["readiness"]);
    }

    /// <summary>
    ///     Adds repositories to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the repositories to.</param>
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRepository<ScaffoldTask>, ScaffoldTaskRepository>();
        services.AddTransient<IScaffoldTaskRepository, ScaffoldTaskRepository>();
    }

    /// <summary>
    ///     Adds strategies to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the strategies to.</param>
    private static void AddStrategies(this IServiceCollection services)
    {
        services.AddTransient<IStrategy<ConsumeResult<string, string>>, GenericIntegrationEventConsumptionStrategy>();
    }
}