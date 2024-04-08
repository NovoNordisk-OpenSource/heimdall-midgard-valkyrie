namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Command handler for retrieving scaffold tasks by id.
/// </summary>
public sealed class GetScaffoldTaskByIdCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<GetScaffoldTaskByIdCommand, ScaffoldTask?>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    ///     Handles the GetScaffoldTaskByDateRangeCommand by calling the domain service to retrieve domain entities within the
    ///     specified date range.
    /// </summary>
    /// <param name="command">The GetScaffoldTaskByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<ScaffoldTask?> Handle(GetScaffoldTaskByIdCommand command, CancellationToken ct = default)
    {
        return await _ScaffoldService.GetScaffoldTaskByIdAsync(command.Id, ct);
    }
}