namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to retrieve domain entities within a specified date range.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="GetScaffoldTaskByIdCommand" /> class.
/// </remarks>
/// <param name="scaffoldTaskId">The id of the scaffold task.</param>
[method: JsonConstructor]
public sealed class GetScaffoldTaskByIdCommand(Guid scaffoldTaskId) : ICommand<ScaffoldTask?>
{
    /// <summary>
    ///     Gets or sets the id.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;
}