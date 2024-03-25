namespace Heimdall.Midgard.Valkyrie.Application.Telemetry;

/// <summary>
///     Represents the activity sources for the application.
/// </summary>
public static class Activities
{
    public static ActivitySource ApplicationActivitySource { get; } = new(Service.Name, Service.Version);
}