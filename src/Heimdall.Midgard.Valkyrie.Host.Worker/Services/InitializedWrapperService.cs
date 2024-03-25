namespace Heimdall.Midgard.Valkyrie.Host.Worker;

/// <summary>
/// Represents a wrapper service that initializes an inner service and provides additional functionality.
/// </summary>
/// <typeparam name="T">The type of the inner service.</typeparam>
public class InitializedWrapperService<T>(T innerService, InitializedHealthCheck? initializedHealthCheck = default) : BackgroundService where T : BackgroundService
{
    private readonly T _innerService = innerService;
    
    private readonly InitializedHealthCheck? _initializedHealthCheck = initializedHealthCheck;

    /// <summary>
    /// Starts the inner service and the wrapper service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await _innerService.StartAsync(cancellationToken);

        await base.StartAsync(cancellationToken);
    }

    /// <summary>
    /// Stops the inner service and the wrapper service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _innerService.StopAsync(cancellationToken);

        await base.StopAsync(cancellationToken);
    }

    /// <summary>
    /// Executes the wrapper service asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        if(_initializedHealthCheck != null)
            _initializedHealthCheck.Initialized = true;

        return Task.CompletedTask;
    }
}