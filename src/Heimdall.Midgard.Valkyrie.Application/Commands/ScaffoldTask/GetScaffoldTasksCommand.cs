namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command to retrieve a collection of domain entities.
/// </summary>
public sealed class GetScaffoldTasksCommand : ICommand<IEnumerable<ScaffoldTask>>
{
    [JsonConstructor]
    public GetScaffoldTasksCommand()
    {
    }
}