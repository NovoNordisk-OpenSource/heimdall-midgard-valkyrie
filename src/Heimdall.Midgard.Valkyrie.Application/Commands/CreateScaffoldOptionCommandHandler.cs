namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Represents a command handler for creating a scaffold option.
/// </summary>
public sealed class CreateScaffoldOptionCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<CreateScaffoldOptionCommand, ScaffoldOption>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    /// Handles the create scaffold option command.
    /// </summary>
    /// <param name="command">The create scaffold option command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created scaffold option.</returns>
    public async Task<ScaffoldOption> Handle(CreateScaffoldOptionCommand command, CancellationToken cancellationToken = default)
    {
        return await _ScaffoldService.AddOrUpdateScaffoldOptionAsync(command.EntityId, command.Key, command.Value, cancellationToken);
    }
}