namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Initializes a new instance of the <see cref="CreateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="scaffoldTaskId">The scaffold task identifier.</param>
/// <param name="key">The scaffold option key.</param>
/// <param name="value">The scaffold option value.</param>
[method: JsonConstructor]
public sealed class CreateScaffoldOptionCommand(Guid scaffoldTaskId, string key, string value) : ICommand<ScaffoldOption>
{
    /// <summary>
    /// Gets or sets the scaffold task identifier.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;

    /// <summary>
    /// Gets or sets the scaffold option key.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    /// Gets or sets the scaffold option value.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; init; } = value;
}