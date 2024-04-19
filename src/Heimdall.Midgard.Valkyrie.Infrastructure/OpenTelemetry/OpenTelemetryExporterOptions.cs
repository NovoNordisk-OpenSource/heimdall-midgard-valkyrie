/// <summary>
/// Represents the available options for configuring OpenTelemetry exporter.
/// </summary>
namespace Heimdall.Midgard.Valkyrie.Infrastructure.OpenTelemetry;

public class OpenTelemetryExporterOptions
{
    public string? Endpoint { get; set; }
}