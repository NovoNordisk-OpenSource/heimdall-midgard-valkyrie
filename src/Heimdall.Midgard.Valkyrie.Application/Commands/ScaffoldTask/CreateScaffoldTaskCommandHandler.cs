namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for creating a scaffold task.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="CreateScaffoldTaskCommandHandler" /> class.
/// </remarks>
/// <param name="ScaffoldService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the ScaffoldService is null.</exception>
public sealed class CreateScaffoldTaskCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<CreateScaffoldTaskCommand, ScaffoldTask>, ICommandHandler<CreateScaffoldTaskCommand, IAggregateRoot>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    ///     Handles the create scaffold task command.
    /// </summary>
    /// <param name="command">The create scaffold task command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The created scaffold task.</returns>
    public async Task<ScaffoldTask> Handle(CreateScaffoldTaskCommand command, CancellationToken ct = default)
    {
        return await _ScaffoldService.AddScaffoldTaskAsync(command.Options, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<CreateScaffoldTaskCommand, IAggregateRoot>.Handle(CreateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<CreateScaffoldTaskCommand, IAggregateRoot>.Handle(CreateScaffoldTaskCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}