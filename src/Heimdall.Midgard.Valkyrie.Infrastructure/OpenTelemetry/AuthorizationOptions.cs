/// <summary>
/// Represents the available options for authorization in OpenTelemetry.
/// </summary>
namespace Heimdall.Midgard.Valkyrie.Infrastructure.OpenTelemetry;

public enum AuthorizationOptions
{
    NoAuth,
    ServicePrincipal,
    SystemAssignedIdentity,
    UserAssignedIdentity
}