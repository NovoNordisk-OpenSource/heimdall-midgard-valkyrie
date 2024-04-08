namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Initializes a new instance of the <see cref="CreateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="entityId">The entity identifier.</param>
/// <param name="label">The label.</param>
/// <param name="capabilityIdentifier">The capability identifier.</param>
[method: JsonConstructor]
public sealed class DeleteScaffoldOptionCommand(Guid scaffoldTaskId, string key) : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the key of the scaffold option.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    /// Gets or sets the ID of the scaffold task.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;
}