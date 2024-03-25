namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework;

/// <summary>
///     Represents the application context for the Entity Framework.
/// </summary>
public class ApplicationContext : EntityContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ApplicationContext" /> class.
    /// </summary>
    public ApplicationContext()
    {
    }

#pragma warning disable CS8625
    /// <summary>
    ///     Initializes a new instance of the <see cref="ApplicationContext" /> class with the specified options, mediator, and
    ///     seed data.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    /// <param name="mediator">The mediator instance.</param>
    /// <param name="seedData">The seed data for the context.</param>
    public ApplicationContext(DbContextOptions options, IMediator? mediator = default, IDictionary<Type, IEnumerable<IView>> seedData = default) : base(options)
    {
    }
#pragma warning restore CS8625
    /// <summary>
    ///     Gets or sets the DbSet for the domain entities.
    /// </summary>
    public virtual DbSet<ScaffoldTask> ScaffoldTasks { get; set; }

    /// <summary>
    ///     Gets or sets the DbSet for the scaffold options.
    /// </summary>
    public virtual DbSet<ScaffoldOption> ScaffoldOptions { get; set; }
}