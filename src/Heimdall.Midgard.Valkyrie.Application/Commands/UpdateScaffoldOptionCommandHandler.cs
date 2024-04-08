namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Represents a command handler for updating a scaffold option.
/// </summary>
public sealed class UpdateScaffoldOptionCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<UpdateScaffoldOptionCommand, ScaffoldOption>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    /// Handles the update scaffold option command.
    /// </summary>
    /// <param name="command">The update scaffold option command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The updated scaffold option.</returns>
    public async Task<ScaffoldOption> Handle(UpdateScaffoldOptionCommand command, CancellationToken cancellationToken = default)
    {
        return await _ScaffoldService.AddOrUpdateScaffoldOptionAsync(command.EntityId, command.Label, command.Value, cancellationToken);
    }
}