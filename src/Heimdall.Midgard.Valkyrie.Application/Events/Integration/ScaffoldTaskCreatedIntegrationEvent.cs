namespace Heimdall.Midgard.Valkyrie.Application.Events.Integration;

/// <summary>
///     Represents an integration event that is raised when a scaffold task is created.
/// </summary>
public class ScaffoldTaskCreatedIntegrationEvent : IIntegrationEvent
{
    /// <summary>
    ///     Gets or sets the ID of the integration event.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or sets the correlation ID of the integration event.
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or sets the creation date of the integration event.
    /// </summary>
    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    /// <summary>
    ///     Gets or sets the schema version of the integration event.
    /// </summary>
    [JsonPropertyName("schemaVersion")]
    public string SchemaVersion { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or sets the type of the integration event.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or sets the payload of the integration event.
    /// </summary>
    [JsonPropertyName("payload")]
    public JsonElement? Payload { get; init; }
}