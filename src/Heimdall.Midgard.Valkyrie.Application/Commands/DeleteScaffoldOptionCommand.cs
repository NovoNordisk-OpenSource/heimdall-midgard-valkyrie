namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Initializes a new instance of the <see cref="CreateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="scaffoldTaskId">The scaffold task identifier.</param>
/// <param name="key">The scaffold option key.</param>
[method: JsonConstructor]
public sealed class DeleteScaffoldOptionCommand(Guid scaffoldTaskId, string key) : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the key of the scaffold option to delete.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    /// Gets or sets the ID of the scaffold task containing the option to delete.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;
}