namespace Heimdall.Midgard.Valkyrie.Domain.Events.Domain;

/// <summary>
///     Represents a scaffold task event.
/// </summary>
public abstract class ScaffoldTaskEvent : IDomainEvent
{
    /// <summary>
    ///     Gets or sets the scaffold task associated with the event.
    /// </summary>
    public ScaffoldTask? Entity { get; protected set; }
}