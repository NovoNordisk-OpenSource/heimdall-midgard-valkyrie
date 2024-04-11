namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to update a scaffold task.
/// </summary>
/// <param name="scaffoldTaskId">The scaffold task identifier.</param>
/// <param name="account">The account info to update on a scaffold task.</param>
/// <param name="options">The options to update on a scaffold task.</param>
[method: JsonConstructor]
public sealed class UpdateScaffoldTaskCommand(Guid scaffoldTaskId, AccountInfo account, IEnumerable<ScaffoldOption>? options = default) : ICommand<ScaffoldTask>
{
    /// <summary>
    /// Gets or sets the entity ID.
    /// </summary>
    [JsonPropertyName("scaffoldTaskId")]
    public Guid ScaffoldTaskId { get; init; } = scaffoldTaskId;

    /// <summary>
    ///     Gets or sets the collection of scaffold options associated with the entity.
    /// </summary>
    [JsonPropertyName("options")]
    public IEnumerable<ScaffoldOption>? Options { get; init; } = options;

    /// <summary>
    ///     Gets or sets the account associated with the entity.
    /// </summary>
    [JsonPropertyName("account")]
    public AccountInfo Account { get; init; } = account;
}