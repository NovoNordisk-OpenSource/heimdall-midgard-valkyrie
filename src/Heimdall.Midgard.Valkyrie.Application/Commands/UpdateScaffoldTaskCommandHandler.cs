namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Represents a command handler for updating a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="UpdateScaffoldTaskCommandHandler" /> class.
/// </remarks>
/// <param name="ScaffoldService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the ScaffoldService is null.</exception>
public sealed class UpdateScaffoldTaskCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<UpdateScaffoldTaskCommand, ScaffoldTask?>, ICommandHandler<UpdateScaffoldTaskCommand, IAggregateRoot?>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    ///     Handles the update scaffold task command.
    /// </summary>
    /// <param name="command">The update scaffold task command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The updated scaffold task.</returns>
    public async Task<ScaffoldTask?> Handle(UpdateScaffoldTaskCommand command, CancellationToken ct = default)
    {
        var scaffoldTask = await _scaffoldService.GetScaffoldTaskByIdAsync(command.ScaffoldTaskId, ct);

        if(scaffoldTask is not null){
            if(command.Options is not null)
                scaffoldTask.AddScaffoldOption(command.Options);

            return await _scaffoldService.UpdateScaffoldTaskAsync(scaffoldTask, ct);
        }

        return scaffoldTask;
    }

    async Task<IAggregateRoot?> IRequestHandler<UpdateScaffoldTaskCommand, IAggregateRoot?>.Handle(UpdateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot?> ICommandHandler<UpdateScaffoldTaskCommand, IAggregateRoot?>.Handle(UpdateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}