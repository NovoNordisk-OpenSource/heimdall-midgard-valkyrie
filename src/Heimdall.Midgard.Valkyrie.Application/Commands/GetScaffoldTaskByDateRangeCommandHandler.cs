namespace Heimdall.Midgard.Valkyrie.Application.Commands;

/// <summary>
///     Command handler for retrieving domain entities within a specified date range.
/// </summary>
public sealed class GetScaffoldTaskByDateRangeCommandHandler(IScaffoldService scaffoldService) : ICommandHandler<GetScaffoldTaskByDateRangeCommand, IEnumerable<ScaffoldTask>>
{
    private readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    ///     Handles the GetScaffoldTaskByDateRangeCommand by calling the domain service to retrieve domain entities within the
    ///     specified date range.
    /// </summary>
    /// <param name="command">The GetScaffoldTaskByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<IEnumerable<ScaffoldTask>> Handle(GetScaffoldTaskByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _scaffoldService.GetScaffoldTaskByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}