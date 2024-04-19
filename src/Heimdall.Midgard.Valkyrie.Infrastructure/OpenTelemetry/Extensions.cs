namespace Heimdall.Midgard.Valkyrie.Infrastructure.OpenTelemetry;

/// <summary>
/// Provides extension methods for configuring exporters in OpenTelemetry.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Configures the trace exporter in the TracerProviderBuilder.
    /// </summary>
    /// <param name="builder">The TracerProviderBuilder instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <param name="identityOptions">The MicrosoftIdentityOptions options.</param>
    /// <returns>The TracerProviderBuilder instance.</returns>
    public static TracerProviderBuilder ConfigureTraceExporter(this TracerProviderBuilder builder, MicrosoftIdentityOptions identityOptions, OpenTelemetryExporterOptions? otlpExporterOptions = default)
    {
        if (otlpExporterOptions != null && !string.IsNullOrEmpty(otlpExporterOptions.Endpoint))
            builder.AddOtlpExporter(otlpOptions =>
            {
                otlpOptions.Endpoint = new Uri(otlpExporterOptions.Endpoint);
                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                otlpOptions.HttpClientFactory = () =>
                {
                    var innerHandler = new HttpClientHandler();
                    var client = new HttpClient(
                        new AuthorizationHeaderHandler(
                            innerHandler,
                            identityOptions,
                            AuthorizationOptions.ServicePrincipal
                        )
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            builder.AddConsoleExporter();

        return builder;
    }

    /// <summary>
    /// Configures the meter exporter in the MeterProviderBuilder.
    /// </summary>
    /// <param name="builder">The MeterProviderBuilder instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <param name="identityOptions">The MicrosoftIdentityOptions options.</param>
    /// <returns>The MeterProviderBuilder instance.</returns>
    public static MeterProviderBuilder ConfigureMeterExporter(this MeterProviderBuilder builder, MicrosoftIdentityOptions identityOptions, OpenTelemetryExporterOptions? otlpExporterOptions = default)
    {
        if (otlpExporterOptions != null && !string.IsNullOrEmpty(otlpExporterOptions.Endpoint))
            builder.AddOtlpExporter(otlpOptions =>
            {
                otlpOptions.Endpoint = new Uri(otlpExporterOptions.Endpoint);
                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                otlpOptions.HttpClientFactory = () =>
                {
                    var innerHandler = new HttpClientHandler();
                    var client = new HttpClient(
                        new AuthorizationHeaderHandler(
                            innerHandler,
                            identityOptions,
                            AuthorizationOptions.ServicePrincipal
                        )
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            builder.AddConsoleExporter();

        return builder;
    }

    /// <summary>
    /// Configures the logger exporter in the OpenTelemetryLoggerOptions.
    /// </summary>
    /// <param name="options">The OpenTelemetryLoggerOptions instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <param name="identityOptions">The MicrosoftIdentityOptions options.</param>
    /// <returns>The OpenTelemetryLoggerOptions instance.</returns>
    public static OpenTelemetryLoggerOptions ConfigureLoggerExporter(this OpenTelemetryLoggerOptions options, MicrosoftIdentityOptions identityOptions, OpenTelemetryExporterOptions? otlpExporterOptions = default)
    {
        if (otlpExporterOptions != null && !string.IsNullOrEmpty(otlpExporterOptions.Endpoint))
            options.AddOtlpExporter(otlpOptions =>
            {
                otlpOptions.Endpoint = new Uri(otlpExporterOptions.Endpoint);
                otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                otlpOptions.HttpClientFactory = () =>
                {
                    var innerHandler = new HttpClientHandler();
                    var client = new HttpClient(
                        new AuthorizationHeaderHandler(
                            innerHandler,
                            identityOptions,
                            AuthorizationOptions.ServicePrincipal
                        )
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            options.AddConsoleExporter();

        return options;
    }
} 
