namespace Heimdall.Midgard.Valkyrie.Application.Telemetry;

/// <summary>
///     Represents the metrics for the application.
/// </summary>
public static class Metrics
{
    public static Meter RequestMeter { get; } = new("application.requests", Service.Version);

    public static Meter EventMeter { get; } = new("application.events", Service.Version);
}