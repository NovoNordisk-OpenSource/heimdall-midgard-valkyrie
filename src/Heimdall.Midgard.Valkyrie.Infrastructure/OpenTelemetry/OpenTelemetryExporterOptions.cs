/// <summary>
/// Represents the available options for configuring OpenTelemetry exporter.
/// </summary>
namespace Heimdall.Midgard.Valkyrie.Infrastructure.OpenTelemetry;

public class OpenTelemetryExporterOptions
{
    [Required]
    public string? ClientId { get; set; }

    public string? Endpoint { get; set; }
}