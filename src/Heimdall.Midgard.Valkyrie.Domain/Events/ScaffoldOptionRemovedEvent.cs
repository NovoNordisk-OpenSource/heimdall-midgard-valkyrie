namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold option is removed.
/// </summary>
public sealed class ScaffoldOptionRemovedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldOptionRemovedEvent" /> class.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task from which the object was removed.</param>
    /// <param name="option">The scaffold option that was removed.</param>
    public ScaffoldOptionRemovedEvent(ScaffoldTask scaffoldTask, ScaffoldOption option)
    {
        ScaffoldTask = scaffoldTask;
        Option = option;
    }

    /// <summary>
    ///     Gets the scaffold option that was removed.
    /// </summary>
    public ScaffoldOption Option { get; private set; }
}