namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command handler for deleting a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteScaffoldTaskCommandHandler" /> class.
/// </remarks>
/// <param name="scaffoldService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the ScaffoldService is null.</exception>
public sealed class DeleteScaffoldTaskCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<DeleteScaffoldTaskCommand, bool>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    ///     Handles the delete scaffold task command.
    /// </summary>
    /// <param name="command">The delete scaffold task command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a boolean indicating whether the
    ///     entity was deleted successfully.
    /// </returns>
    public async Task<bool> Handle(DeleteScaffoldTaskCommand command, CancellationToken ct = default)
    {
        return await _scaffoldService.DeleteScaffoldTaskAsync(command.ScaffoldTaskId, ct);
    }
}