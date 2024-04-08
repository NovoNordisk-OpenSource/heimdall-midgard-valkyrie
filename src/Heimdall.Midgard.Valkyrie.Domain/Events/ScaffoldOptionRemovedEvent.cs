namespace Heimdall.Midgard.Valkyrie.Domain.Events;

/// <summary>
///     Represents an event that is raised when a scaffold option is removed.
/// </summary>
public sealed class ScaffoldOptionRemovedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldOptionRemovedEvent" /> class.
    /// </summary>
    /// <param name="entity">The scaffold task from which the object was removed.</param>
    /// <param name="object">The scaffold option that was removed.</param>
    public ScaffoldOptionRemovedEvent(ScaffoldTask entity, ScaffoldOption @object)
    {
        Entity = entity;
        Object = @object;
    }

    /// <summary>
    ///     Gets the scaffold option that was removed.
    /// </summary>
    public ScaffoldOption Object { get; private set; }
}