using Heimdall.Midgard.Valkyrie.Domain.ValueObjects;

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
    ///     Gets all scaffold tasks asynchronously.
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

        //Initialize command to get all scaffold tasks
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

    /// <summary>
    ///     Gets a scaffold task by id asynchronously.
    /// </summary>
    /// <param name="id">The id of the scaffold task.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A matched ScaffoldTask or null.</returns>
    [HttpGet("{id}")]
    public async Task<ScaffoldTask?> GetScaffoldTaskByIdAsync(Guid id, CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get scaffold task by id
        var command = new GetScaffoldTaskByIdCommand(id);

        // Dispatch command to application facade
        var entity = await _facade.Execute(command, ct);

        // Add a tag to the custom activity indicating if a match was found
        activity?.SetTag(nameof(entity), entity?.Id != Guid.Empty ? "Match Found" : "No Match Found");

        // Log the number of entities returned and the id found
        if(entity is not null)
        {
            _logger.LogScaffoldTaskReturnCount(1);
            _logger.LogScaffoldTaskFound(entity.Id);
        }
        
        // Return the match
        return entity;
    }

    /// <summary>
    ///     Gets a scaffold task by id asynchronously.
    /// </summary>
    /// <param name="startDate">The startDate for the range of scaffold tasks to return.</param>
    /// <param name="endDate">The endDate for the range of scaffold tasks to return.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A matched ScaffoldTask or null.</returns>
    [HttpGet("search")]
    public async Task<IEnumerable<ScaffoldTask>> GetScaffoldTaskByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get scaffold tasks by date range
        var command = new GetScaffoldTaskByDateRangeCommand(startDate, endDate);

        // Dispatch command to application facade
        var entities = await _facade.Execute(command, ct);
        var entityCount = entities.Count();

        // Add a tag to the custom activity containing a entity count (replace Hello World!, even thou we love it)
        activity?.SetTag(nameof(entityCount), entityCount);

        // Log the number of entities returned
        _logger.LogScaffoldTaskReturnCount(entityCount);

        foreach(var entity in entities)
        {
            _logger.LogScaffoldTaskFound(entity.Id);
        }

        // Return the match
        return entities;
    }

    /// <summary>
    ///     Adds a new scaffold task.
    /// </summary>
    /// <param name="startDate">The startDate for the range of scaffold tasks to return.</param>
    /// <param name="endDate">The endDate for the range of scaffold tasks to return.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A matched ScaffoldTask or null.</returns>
    [HttpPost]
    public async Task<ScaffoldTask> AddScaffoldTaskAsync([FromBody] CreateScaffoldTaskCommand command, CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        // Dispatch command to application facade
        var entity = await _facade.Execute(command, ct);

        // Add a tag to the custom activity containing the entity id of the newly created entity
        activity?.SetTag(nameof(ScaffoldTask), entity.Id);

        // Log the id of the newly created entity
        _logger.LogScaffoldTaskStatusChange(entity.Id, "Created");

        // Return the newly created entity
        return entity;
    }

    /// <summary>
    ///     Updates an existing scaffold task.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task to update.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A the updated Scaffold Task.</returns>
    [HttpPut("{id}")]
    public async Task<ScaffoldTask> UpdateScaffoldTaskAsync([FromBody] UpdateScaffoldTaskCommand command, CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        // Dispatch command to application facade
        var entity = await _facade.Execute(command, ct);

        // Add a tag to the custom activity containing the entity id of the updated entity
        activity?.SetTag(nameof(ScaffoldTask), entity.Id);

        // Log the id of the updated entity
        _logger.LogScaffoldTaskStatusChange(entity.Id, "Updated");

        // Return the updated entity
        return entity;
    }
    
    /// <summary>
    ///     Updates an existing scaffold task.
    /// </summary>
    /// <param name="scaffoldTask">The scaffold task to update.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A the updated Scaffold Task.</returns>
    [HttpDelete("{id}")]
    public async Task<bool> DeleteScaffoldTaskAsync(Guid id, CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to update scaffold task
        var command = new DeleteScaffoldTaskCommand(id);

        // Dispatch command to application facade
        var result = await _facade.Execute(command, ct);
        
        // Add a tag to the custom activity containing the entity id of the deleted entity
        activity?.SetTag(nameof(ScaffoldTask), id);

        // Log the id of the deleted entity
        _logger.LogScaffoldTaskStatusChange(id, "Deleted");

        // Return the result of the delete operation (boolean)
        return result;
    }
}