namespace Heimdall.Midgard.Valkyrie.Domain.ValueObjects;

/// <summary>
///     Represents a scaffold option with a key and value.
/// </summary>
/// <remarks>
///     Value objects are a concept in software development that represent a descriptive aspect of the domain with no
///     conceptual identity. In simpler terms, value objects are objects whose equality is determined by the value of their
///     attributes rather than by their identity.
///     They are used to model attributes or characteristics of entities (aggregates) in a domain.
/// </remarks>
[method: JsonConstructor]
public sealed class ScaffoldOption(string key, string value) : ValueObject
{
    /// <summary>
    ///     Gets or sets the key of the scaffold setting object.
    /// </summary>
    [Required]
    [JsonPropertyName("key")]
    public string Key { get; init; } = key;

    /// <summary>
    ///     Gets or sets the value of the scaffold option.
    /// </summary>
    [Required]
    [JsonPropertyName("value")]
    public string Value { get; init; } = value;

    /// <summary>
    ///     Returns the atomic values of the scaffold option.
    /// </summary>
    /// <returns>An enumerable of the atomic values.</returns>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
        yield return Value;
    }
}