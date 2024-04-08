namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Command handler for retrieving scaffold tasks by id.
/// </summary>
public sealed class GetScaffoldTaskByIdCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<GetScaffoldTaskByIdCommand, ScaffoldTask?>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    ///     Handles the GetScaffoldTaskByDateRangeCommand by calling the domain service to retrieve domain entities within the
    ///     specified date range.
    /// </summary>
    /// <param name="command">The GetScaffoldTaskByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<ScaffoldTask?> Handle(GetScaffoldTaskByIdCommand command, CancellationToken ct = default)
    {
        return await _scaffoldService.GetScaffoldTaskByIdAsync(command.ScaffoldTaskId, ct);
    }
}