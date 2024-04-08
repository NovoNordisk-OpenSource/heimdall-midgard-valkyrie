namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to retrieve a collection of all scaffold talks.
/// </summary>
public sealed class GetScaffoldTasksCommand : ICommand<IEnumerable<ScaffoldTask>>
{
    [JsonConstructor]
    public GetScaffoldTasksCommand()
    {
    }
}