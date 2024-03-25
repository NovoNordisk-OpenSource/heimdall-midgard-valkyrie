namespace Heimdall.Midgard.Valkyrie.Domain.Aggregates;

/// <summary>
///     Represents a scaffold task.
/// </summary>
/// <remarks>
///     The Aggregate Root is a design pattern that's used in Domain-Driven Design (DDD). It's a part of the tactical
///     design patterns set which also includes Entities, Value Objects, and Domain Events.
///     An Aggregate is a cluster of scaffold options that can be treated as a single unit. An example may be an Order and
///     its line-items, these will be separate objects, but it's useful to treat the Order (along with its line items) as a
///     single aggregate.
///     An Aggregate Root is the object or entity that holds the aggregate together. It's the gatekeeper to the aggregate
///     and all interactions with the aggregate should go through the Aggregate Root. In the previous example, the Order
///     would be the Aggregate Root.
///     The Aggregate Root has the following responsibilities:
///     Ensures the consistency of changes being made within the aggregate boundary: The Aggregate Root is responsible for
///     checking the validity of the operation before it changes the state of the aggregate.
///     Controls access to the aggregate: The Aggregate Root is the only point of access for other objects. This means that
///     other objects can't directly access the contained entities or value objects.
///     Maintains the lifecycle of the aggregate: The Aggregate Root is responsible for the creation and deletion of the
///     aggregate.
///     In your code, ScaffoldTask is an Aggregate Root as it implements the IAggregateRoot interface. This means that
///     ScaffoldTask is the entry point for any operations that involve the aggregate it's part of.
/// </remarks>
public sealed class ScaffoldTask : Entity<Guid>, IAggregateRoot
{
    private readonly List<ScaffoldOption> _options = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldTask" /> class.
    /// </summary>
    public ScaffoldTask()
    {
        var evt = new ScaffoldTaskCreatedEvent(this);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Gets the collection of scaffold options associated with this entity.
    /// </summary>
    public IEnumerable<ScaffoldOption> Options => _options.AsReadOnly();

    /// <summary>
    ///     Gets the creation date and time of this entity.
    /// </summary>
    public DateTime Created { get; } = DateTime.UtcNow;
    
    /// <summary>
    ///     Gets the AccountIdentifier of this entity.
    /// </summary>
    public string AccountIdentifier { get; } = string.Empty;
    
    /// <summary>
    ///     Gets the AccountRole of this entity.
    /// </summary>
    public string AccountRole { get; } = string.Empty;

    /// <summary>
    ///     Validates the entity.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of validation results.</returns>
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }

    /// <summary>
    ///     Adds a scaffold option to the entity.
    /// </summary>
    /// <param name="option">The scaffold option to add.</param>
    public void AddScaffoldOption(ScaffoldOption option)
    {
        _options.Add(option);

        var evt = new ScaffoldOptionAddedEvent(this, option);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Adds multiple scaffold options to the collection of objects associated with this entity.
    /// </summary>
    /// <param name="options">The collection of scaffold options to add.</param>
    public void AddScaffoldOption(IEnumerable<ScaffoldOption> options)
    {
        foreach (var option in options)
            AddScaffoldOption(option);
    }

    /// <summary>
    ///     Removes a scaffold option from the collection of objects associated with this entity.
    /// </summary>
    /// <param name="option">The scaffold option to remove.</param>
    public void RemoveScaffoldOption(ScaffoldOption option)
    {
        _options.Remove(option);

        var evt = new ScaffoldOptionAddedEvent(this, option);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Removes multiple scaffold options associated with this entity.
    /// </summary>
    /// <param name="options">The collection of scaffold options to remove.</param>
    public void RemoveScaffoldOption(IEnumerable<ScaffoldOption> options)
    {
        foreach (var option in options)
            RemoveScaffoldOption(option);
    }
}