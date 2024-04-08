namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Initializes a new instance of the <see cref="CreateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="capabilityIdentifier">The capability identifier.</param>
/// <param name="key">The key.</param>
/// <param name="value">The value.</param>
/// <param name="entityId">The entity identifier.</param>
[method: JsonConstructor]
public sealed class CreateScaffoldOptionCommand(Guid scaffoldTaskId, string key, string value) : ICommand<ScaffoldOption>
{
    /// <summary>
    /// Gets or sets the entity ID.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; init; } = value;
}