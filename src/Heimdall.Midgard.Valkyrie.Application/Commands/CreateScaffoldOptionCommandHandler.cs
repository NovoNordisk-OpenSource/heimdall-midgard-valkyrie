namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Represents a command handler for creating a scaffold option.
/// </summary>
public sealed class CreateScaffoldOptionCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<CreateScaffoldOptionCommand, ScaffoldOption>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    /// Handles the create scaffold option command.
    /// </summary>
    /// <param name="command">The create scaffold option command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created scaffold option.</returns>
    public async Task<ScaffoldOption> Handle(CreateScaffoldOptionCommand command, CancellationToken cancellationToken = default)
    {
        return await _scaffoldService.AddOrUpdateScaffoldOptionAsync(command.ScaffoldTaskId, command.Key, command.Value, cancellationToken);
    }
}