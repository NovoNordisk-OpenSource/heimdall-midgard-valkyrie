namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold task is created.
/// </summary>
public sealed class ScaffoldTaskCreatedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldTaskCreatedEvent" /> class.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task that was created.</param>
    public ScaffoldTaskCreatedEvent(ScaffoldTask scaffoldTask)
    {
        ScaffoldTask = scaffoldTask;
    }
}