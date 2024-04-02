namespace Heimdall.Midgard.Valkyrie.Domain.ValueObjects;

/// <summary>
///     Represents a account info object.
/// </summary>
/// <remarks>
///     Value objects are a concept in software development that represent a descriptive aspect of the domain with no
///     conceptual identity. In simpler terms, value objects are objects whose equality is determined by the value of their
///     attributes rather than by their identity.
///     They are used to model attributes or characteristics of entities (aggregates) in a domain.
/// </remarks>
[method: JsonConstructor]
public sealed class AccountInfo(string identifier, string role) : ValueObject
{
    /// <summary>
    ///     Gets or sets the key of the scaffold account identifier.
    /// </summary>
    [Required]
    [JsonPropertyName("identifier")]
    public string Identifier { get; init; } = identifier;

    /// <summary>
    ///     Gets or sets the value of the scaffold account role.
    /// </summary>
    [Required]
    [JsonPropertyName("role")]
    public string Role { get; init; } = role;

    /// <summary>
    ///     Gets the account provider value computed based on the identifier.
    /// </summary>
    public string Provider  => Guid.TryParse(Identifier, out _) ? "azure" : "aws";

    /// <summary>
    ///     Returns the atomic values of the account info object.
    /// </summary>
    /// <returns>An enumerable of the atomic values.</returns>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Identifier;
        yield return Role;
    }
}