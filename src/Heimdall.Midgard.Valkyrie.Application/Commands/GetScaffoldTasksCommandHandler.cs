namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Command handler for retrieving domain entities.
/// </summary>
public sealed class GetScaffoldTasksCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<GetScaffoldTasksCommand, IEnumerable<ScaffoldTask>>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    ///     Handles the GetDomainEntitiesCommand by retrieving domain entities asynchronously.
    /// </summary>
    /// <param name="command">The GetScaffoldTasksCommand.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<ScaffoldTask>> Handle(GetScaffoldTasksCommand command, CancellationToken ct = default)
    {
        return await _ScaffoldService.GetScaffoldTasksAsync(ct);
    }
}