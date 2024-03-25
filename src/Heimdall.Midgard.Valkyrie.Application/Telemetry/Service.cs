namespace Heimdall.Midgard.Valkyrie.Application.Telemetry;

/// <summary>
///     Represents a service for telemetry purposes.
/// </summary>
public static class Service
{
    /// <summary>
    ///     Gets the name of the service.
    /// </summary>
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    public static string Name { get; } = typeof(Service).AssemblyQualifiedName.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    /// <summary>
    ///     Gets the version of the service.
    /// </summary>
    public static string Version { get; } = typeof(Service).Assembly.ManifestModule.ModuleVersionId.ToString();
}