namespace Heimdall.Midgard.Valkyrie.Application;

/// <summary>
///     Provides extension methods to configure dependency injection for the application layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Configures the application layer dependencies.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the dependencies to.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        // Framework dependencies
        services.AddLogging();

        // Upstream dependencies            
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Application dependencies        
        services.AddFacade();
        services.AddServices();
    }

    private static void AddFacade(this IServiceCollection services)
    {
        services.AddTransient<IApplicationFacade, ApplicationFacade>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IScaffoldService, ScaffoldService>();
    }
}