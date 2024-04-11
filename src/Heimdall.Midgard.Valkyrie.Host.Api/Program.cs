// Create application builder
var builder = WebApplication.CreateBuilder(args);

// Fetch OTLP exporter options from configuration.
var otlpExporterOptions = builder.Configuration.GetSection("OpenTelemetryExporter").Get<OpenTelemetryExporterOptions>() ?? new OpenTelemetryExporterOptions();

// Fetch Microsoft Identity options from configuration.
var microsoftIdentityOptions = builder.Configuration.GetSection("AzureAd").Get<MicrosoftIdentityOptions>() ?? new MicrosoftIdentityOptions();

// Add required services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraph(builder.Configuration.GetSection("GraphBeta"))
    .AddInMemoryTokenCaches();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();

// Add OpenTelemetry dependencies
builder.Services.AddOpenTelemetry()
    // Configure OpenTelemetry Traces
    .WithTracing(builder =>
    {
        builder.AddSource(Service.Name)
            .ConfigureResource(resource =>
                resource.AddService(
                    Service.Name,
                    serviceVersion: Service.Version))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .ConfigureTraceExporter(microsoftIdentityOptions, otlpExporterOptions);
    })
    // Configure OpenTelemetry Metrics
    .WithMetrics(builder =>
    {
        builder.AddMeter(Metrics.RequestMeter.Name)
            .AddMeter(Metrics.EventMeter.Name)
            .AddMeter("Microsoft.AspNetCore.Hosting")
            .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
            .ConfigureMeterExporter(microsoftIdentityOptions, otlpExporterOptions);
    });

// Configure OpenTelemetry Logs
builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeScopes = true;

    var resourceBuilder = ResourceBuilder
        .CreateDefault()
        .AddService(Service.Name);

    logging.SetResourceBuilder(resourceBuilder).ConfigureLoggerExporter(microsoftIdentityOptions, otlpExporterOptions);
});

// Add AsyncAPI documentation
builder.Services.AddAsyncApiSchemaGeneration(options =>
{
    options.AssemblyMarkerTypes = [typeof(ScaffoldTaskCreatedIntegrationEventHandler)];
    options.Middleware.Route = "/discovery/v1/asyncapi/schema.json";
    options.Middleware.UiBaseRoute = "/discovery/v1/asyncapi/";
    options.Middleware.UiTitle = "Midgard Event API Documentation";
    options.AsyncApi = new AsyncApiDocument
    {
        Info = new Info("Midgard Event API", "1.0.0")
        {
            License = new License("Apache 2.0")
            {
                Url = "https://www.apache.org/licenses/LICENSE-2.0"
            }
        },
        Servers =
        {
            { "kafka", new Server("kafka:9092", "kafka") }
        }
    };
});

// Build application
var app = builder.Build();

// Add swagger 
app.UseSwagger(options => {
    options.RouteTemplate = "/discovery/{documentName}/openapi/schema.json";
});

// Add AsyncAPI documentation
app.MapAsyncApiDocuments();

// Add swagger & async UI if development mode.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/discovery/v1/openapi/schema.json", "v1");
        options.RoutePrefix = "discovery/v1/openapi";
    });

    app.MapAsyncApiUi();
}

// Use AzureKeyVault in production if KeyVaultName is set. 
if (builder.Environment.IsProduction() && !string.IsNullOrEmpty(builder.Configuration["KeyVaultName"]) && builder.Configuration["KeyVaultName"] != "[Enter_the_KeyVault_Name_Here]")
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential(new DefaultAzureCredentialOptions
    {
        ManagedIdentityClientId = microsoftIdentityOptions.UserAssignedManagedIdentityClientId
    }));
}

// Add readiness health check to check EF Core DbContext is connected.
app.MapHealthChecks("/healthz/readiness", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("readiness"),   
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

// Add liveness health check to enable monitoring of application lifecycle.
app.MapHealthChecks("/healthz/liveness", new HealthCheckOptions
{
    Predicate = _ => false
});

// Map controllers routes.
app.MapControllers();

// Log the process id.
app.Logger.LogStarting(Environment.ProcessId);

// Start the application.
app.Run();

// Make the program class public to enable testing.
public partial class Program { }