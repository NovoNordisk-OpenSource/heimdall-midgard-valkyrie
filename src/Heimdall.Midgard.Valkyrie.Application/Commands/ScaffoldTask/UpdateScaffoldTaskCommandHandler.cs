namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for updating a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="UpdateScaffoldTaskCommandHandler" /> class.
/// </remarks>
/// <param name="ScaffoldService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the ScaffoldService is null.</exception>
public sealed class UpdateScaffoldTaskCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<UpdateScaffoldTaskCommand, ScaffoldTask>, ICommandHandler<UpdateScaffoldTaskCommand, IAggregateRoot>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    ///     Handles the update scaffold task command.
    /// </summary>
    /// <param name="command">The update scaffold task command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The updated scaffold task.</returns>
    public async Task<ScaffoldTask> Handle(UpdateScaffoldTaskCommand command, CancellationToken ct = default)
    {
        return await _ScaffoldService.UpdateScaffoldTaskAsync(command.Entity, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<UpdateScaffoldTaskCommand, IAggregateRoot>.Handle(UpdateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<UpdateScaffoldTaskCommand, IAggregateRoot>.Handle(UpdateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}