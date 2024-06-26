namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to create a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="CreateScaffoldTaskCommand" /> class.
/// </remarks>
/// <param name="account">The account associated with the scaffold task.</param>
/// <param name="options">The collection of scaffold options associated with the scaffold task.</param>
[method: JsonConstructor]
public sealed class CreateScaffoldTaskCommand(AccountInfo account, IEnumerable<ScaffoldOption> options) : ICommand<ScaffoldTask>
{
    /// <summary>
    ///     Gets or sets the collection of scaffold options associated with the scaffold task.
    /// </summary>
    [JsonPropertyName("options")]
    public IEnumerable<ScaffoldOption> Options { get; init; } = options;

    /// <summary>
    ///     Gets or sets the account associated with the scaffold task.
    /// </summary>
    [JsonPropertyName("account")]
    public AccountInfo Account { get; init; } = account;
}