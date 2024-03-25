namespace Heimdall.Midgard.Valkyrie.Domain.Events.Domain;

/// <summary>
///     Represents an event that is raised when a scaffold option is added.
/// </summary>
public sealed class ScaffoldOptionAddedEvent : ScaffoldTaskEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaffoldOptionAddedEvent" /> class.
    /// </summary>
    /// <param name="entity">The scaffold task to which the object was added.</param>
    /// <param name="object">The scaffold option that was added.</param>
    public ScaffoldOptionAddedEvent(ScaffoldTask entity, ScaffoldOption @object)
    {
        Entity = entity;
        Object = @object;
    }

    /// <summary>
    ///     Gets the scaffold option that was added.
    /// </summary>
    public ScaffoldOption Object { get; private set; }
}