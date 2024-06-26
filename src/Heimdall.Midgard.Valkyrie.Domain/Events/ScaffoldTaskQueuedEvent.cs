namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold task is created.
/// </summary>
public sealed class ScaffoldTaskQueuedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldTaskCreatedEvent" /> class.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task that was queued.</param>
    public ScaffoldTaskQueuedEvent(ScaffoldTask scaffoldTask)
    {
        ScaffoldTask = scaffoldTask;
    }
}