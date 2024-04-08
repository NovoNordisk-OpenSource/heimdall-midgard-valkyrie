namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to delete a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteScaffoldTaskCommand" /> class.
/// </remarks>
/// <param name="entityId">The ID of the entity to be deleted.</param>
[method: JsonConstructor]
public sealed class DeleteScaffoldTaskCommand(Guid id) : ICommand<bool>
{
    /// <summary>
    ///     Gets or sets the ID of the entity to be deleted.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; } = id;
}