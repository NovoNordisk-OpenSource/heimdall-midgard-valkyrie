namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold option is added.
/// </summary>
public sealed class ScaffoldOptionAddedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldOptionAddedEvent" /> class.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task to which the object was added.</param>
    /// <param name="option">The scaffold option that was added.</param>
    public ScaffoldOptionAddedEvent(ScaffoldTask scaffoldTask, ScaffoldOption option)
    {
        ScaffoldTask = scaffoldTask;
        Option = option;
    }

    /// <summary>
    ///     Gets the scaffold option that was added.
    /// </summary>
    public ScaffoldOption Option { get; private set; }
}