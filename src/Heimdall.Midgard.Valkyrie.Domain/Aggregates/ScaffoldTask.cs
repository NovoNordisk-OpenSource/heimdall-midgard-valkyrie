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
public sealed class ScaffoldTask : AggregateRoot<Guid>
{
    private ScaffoldTaskStatus _status = ScaffoldTaskStatus.Created;

    #pragma warning disable IDE0052 // Remove unread private members
    private int _statusId = ScaffoldTaskStatus.Created.Id;
    #pragma warning restore IDE0052 // Remove unread private members

    private readonly List<ScaffoldOption> _options = [];

    /// <summary>
    ///     Gets the collection of scaffold options associated with this entity.
    /// </summary>
    public IEnumerable<ScaffoldOption> Options => _options.AsReadOnly();

    /// <summary>
    ///     Gets the creation date and time of this entity.
    /// </summary>
    public DateTime Created { get; } = DateTime.UtcNow;
    
    /// <summary>
    ///     Gets the AccountInfo object of this entity.
    /// </summary>
    public AccountInfo Account { get; private set; } = new AccountInfo("default", "default");

    /// <summary>
    /// Gets or sets the status of the scaffold task.
    /// </summary>
    public ScaffoldTaskStatus Status
    {
        get
        {
            return _status;
        }
        private set
        {
            _status = value;
            _statusId = _status.Id;
        }
    }

    private ScaffoldTask() : base()
    {
        var evt = new ScaffoldTaskCreatedEvent(this);

        AddDomainEvent(evt);
    }

    public ScaffoldTask(AccountInfo accountInfo) : this()
    {
        Account = accountInfo;
    }

    /// <summary>
    /// Marks the scaffold task as queued.
    /// </summary>
    public void Queue()
    {
        if (Status != ScaffoldTaskStatus.Created)
        {
            return;
        }

        Status = ScaffoldTaskStatus.Queued;

        AddDomainEvent(new ScaffoldTaskQueuedEvent(this));
    }

    /// <summary>
    /// Marks the scaffold task as completed.
    /// </summary>
    public void Complete()
    {
        if (Status != ScaffoldTaskStatus.Queued)
        {
            return;
        }

        Status = ScaffoldTaskStatus.Completed;

        AddDomainEvent(new ScaffoldTaskCompletedEvent(this));
    }

    /// <summary>
    /// Marks the scaffold task as failed.
    /// </summary>
    public void Fail()
    {
        if (Status != ScaffoldTaskStatus.Queued)
        {
            return;
        }

        Status = ScaffoldTaskStatus.Failed;

        AddDomainEvent(new ScaffoldTaskCompletedEvent(this));
    }

    /// <summary>
    /// Marks the scaffold task as cancelled.
    /// </summary>
    public void Cancel()
    {
        if (Status != ScaffoldTaskStatus.Queued)
        {
            return;
        }

        Status = ScaffoldTaskStatus.Cancelled;

        AddDomainEvent(new ScaffoldTaskCompletedEvent(this));
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

    /// <summary>
    ///     Validates the entity.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of validation results.</returns>
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }
}