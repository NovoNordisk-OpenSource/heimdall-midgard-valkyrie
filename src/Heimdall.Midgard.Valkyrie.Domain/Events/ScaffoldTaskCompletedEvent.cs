namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold task is created.
/// </summary>
public sealed class ScaffoldTaskCompletedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldTaskCompletedEvent" /> class.
    /// </summary>
    /// <param name="entity">The scaffold task that was completed.</param>
    public ScaffoldTaskCompletedEvent(ScaffoldTask entity)
    {
        Entity = entity;
    }
}