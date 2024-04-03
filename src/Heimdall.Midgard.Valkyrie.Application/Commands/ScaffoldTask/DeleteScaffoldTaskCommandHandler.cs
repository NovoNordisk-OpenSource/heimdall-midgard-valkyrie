namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for deleting a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteScaffoldTaskCommandHandler" /> class.
/// </remarks>
/// <param name="ScaffoldService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the ScaffoldService is null.</exception>
public sealed class DeleteScaffoldTaskCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<DeleteScaffoldTaskCommand, bool>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

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
        return await _ScaffoldService.DeleteScaffoldTaskAsync(command.Id, ct);
    }
}