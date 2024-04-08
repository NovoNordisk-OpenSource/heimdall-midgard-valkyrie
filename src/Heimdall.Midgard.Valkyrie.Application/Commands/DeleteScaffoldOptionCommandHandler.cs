namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
/// Represents a command handler for deleting a scaffold option.
/// </summary>
public sealed class DeleteScaffoldOptionCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<DeleteScaffoldOptionCommand, bool>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    /// Handles the delete scaffold option command.
    /// </summary>
    /// <param name="command">The delete scaffold option command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task<bool> Handle(DeleteScaffoldOptionCommand command, CancellationToken cancellationToken = default)
    {
        return await _scaffoldService.DeleteScaffoldOptionAsync(command.ScaffoldTaskId, command.Key, cancellationToken);
    }
}