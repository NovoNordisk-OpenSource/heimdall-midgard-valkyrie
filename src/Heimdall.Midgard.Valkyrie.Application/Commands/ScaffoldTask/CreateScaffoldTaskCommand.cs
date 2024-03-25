namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command to create a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="CreateScaffoldTaskCommand" /> class.
/// </remarks>
/// <param name="options">The collection of scaffold options associated with the entity.</param>
[method: JsonConstructor]
public sealed class CreateScaffoldTaskCommand(IEnumerable<ScaffoldOption> options) : ICommand<ScaffoldTask>
{
    /// <summary>
    ///     Gets or sets the collection of scaffold options associated with the entity.
    /// </summary>
    [JsonPropertyName("options")]
    public IEnumerable<ScaffoldOption> Options { get; init; } = options;
}