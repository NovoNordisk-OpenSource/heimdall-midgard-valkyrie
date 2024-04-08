namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command to update a scaffold task.
/// </summary>
[method: JsonConstructor]
/// <summary>
///     Represents a command to update a scaffold task.
/// </summary>
public sealed class UpdateScaffoldTaskCommand(ScaffoldTask entity) : ICommand<ScaffoldTask>
{
    [JsonPropertyName("entity")] 
    public ScaffoldTask Entity { get; init; } = entity;
}