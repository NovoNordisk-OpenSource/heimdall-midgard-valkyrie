namespace Heimdall.Midgard.Valkyrie.Infrastructure.HealthChecks;

/// <summary>
/// Represents a health check that verifies if a process has been successfully initialized.
/// </summary>
public sealed class InitializedHealthCheck : IHealthCheck
{
    private volatile bool _isInitialized;

    /// <summary>
    /// Gets or sets a value indicating whether the process has been initialized.
    /// </summary>
    public bool Initialized
    {
        get => _isInitialized;
        set => _isInitialized = value;
    }

    /// <summary>
    /// Checks the health of the process.
    /// </summary>
    /// <param name="context">The <see cref="HealthCheckContext"/> containing information about the health check.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the health check operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous health check operation.</returns>
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (Initialized)
            return Task.FromResult(HealthCheckResult.Healthy("Process was successfully initialized."));

        return Task.FromResult(HealthCheckResult.Unhealthy("Process is still initializing."));
    }
}