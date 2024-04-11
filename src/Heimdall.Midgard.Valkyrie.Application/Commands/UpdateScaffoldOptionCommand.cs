/// <summary>
/// Initializes a new instance of the <see cref="UpdateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="scaffoldTaskId">The entity identifier.</param>
/// <param name="key">The key.</param>
/// <param name="value">The value.</param>
namespace Heimdall.Midgard.Valkyrie.Application.Commands;

[method: JsonConstructor]
public sealed class UpdateScaffoldOptionCommand(Guid scaffoldTaskId, string key, string value) : ICommand<ScaffoldOption>
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