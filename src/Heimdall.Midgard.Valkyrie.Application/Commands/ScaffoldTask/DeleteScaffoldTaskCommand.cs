namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command to delete a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteScaffoldTaskCommand" /> class.
/// </remarks>
/// <param name="entityId">The ID of the entity to be deleted.</param>
[method: JsonConstructor]
public sealed class DeleteScaffoldTaskCommand(Guid entityId) : ICommand<bool>
{

    /// <summary>
    ///     Gets or sets the ID of the entity to be deleted.
    /// </summary>
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}