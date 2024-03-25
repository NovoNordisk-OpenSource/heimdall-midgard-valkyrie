namespace Heimdall.Midgard.Valkyrie.Application.Commands.Domain;

/// <summary>
///     Command handler for retrieving domain entities within a specified date range.
/// </summary>
public sealed class GetScaffoldTaskByDateRangeCommandHandler(IScaffoldService ScaffoldService) : ICommandHandler<GetScaffoldTaskByDateRangeCommand, IEnumerable<ScaffoldTask>>
{
    private readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    ///     Handles the GetScaffoldTaskByDateRangeCommand by calling the domain service to retrieve domain entities within the
    ///     specified date range.
    /// </summary>
    /// <param name="command">The GetScaffoldTaskByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<IEnumerable<ScaffoldTask>> Handle(GetScaffoldTaskByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _ScaffoldService.GetScaffoldTaskByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}