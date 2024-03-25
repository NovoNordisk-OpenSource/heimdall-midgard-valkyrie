namespace Heimdall.Midgard.Valkyrie.Host.Api.Controllers;

/// <summary>
///     Represents a controller for managing domain entities.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="ScaffoldController" /> class.
/// </remarks>
/// <param name="logger">The logger instance.</param>
/// <param name="facade">The application facade instance.</param>
[Route("api/[controller]")]
[ApiController]
public class ScaffoldController(ILogger<ScaffoldController> logger, IApplicationFacade facade) : ControllerBase
{
    private readonly IApplicationFacade _facade = facade;

    private readonly ILogger<ScaffoldController> _logger = logger;

    private readonly Counter<int> _requestCounter = Metrics.RequestMeter.CreateCounter<int>("request.counter", description: "Counts the number of requests serviced by the controller");

    /// <summary>
    ///     Gets all domain entities asynchronously.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    [HttpGet]
    public async Task<IEnumerable<ScaffoldTask>> GetScaffoldTasksAsync(CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get all domain entities
        var command = new GetScaffoldTasksCommand();

        // Dispatch command to application facade
        var entities = await _facade.Execute(command, ct);
        var entityCount = entities.Count();

        // Add a tag to the custom activity containing a entity count (replace Hello World!, even thou we love it)
        activity?.SetTag(nameof(entityCount), entityCount);

        // Log the number of entities returned
        _logger.LogScaffoldTaskReturnCount(entityCount);

        // Return the found entities
        return entities;
    }

    //TODO: Implement controller actions for remaining commands
}