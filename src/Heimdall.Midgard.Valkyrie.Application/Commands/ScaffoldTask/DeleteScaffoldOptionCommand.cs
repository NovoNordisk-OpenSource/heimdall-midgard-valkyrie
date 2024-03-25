namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
/// Initializes a new instance of the <see cref="CreateScaffoldOptionCommand"/> class.
/// </summary>
/// <param name="entityId">The entity identifier.</param>
/// <param name="label">The label.</param>
/// <param name="capabilityIdentifier">The capability identifier.</param>
[method: JsonConstructor]
public sealed class DeleteScaffoldOptionCommand(Guid entityId, string key) : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the label of the scaffold option.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    /// Gets or sets the ID of the scaffold option.
    /// </summary>
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}