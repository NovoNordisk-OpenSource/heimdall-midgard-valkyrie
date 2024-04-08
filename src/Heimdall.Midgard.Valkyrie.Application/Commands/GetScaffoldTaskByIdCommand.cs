namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to retrieve domain entities within a specified date range.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="GetScaffoldTaskByIdCommand" /> class.
/// </remarks>
/// <param name="id">The if of the scaffold task.</param>
[method: JsonConstructor]
public sealed class GetScaffoldTaskByIdCommand(Guid id) : ICommand<ScaffoldTask?>
{
    /// <summary>
    ///     Gets or sets the id.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; } = id;
}