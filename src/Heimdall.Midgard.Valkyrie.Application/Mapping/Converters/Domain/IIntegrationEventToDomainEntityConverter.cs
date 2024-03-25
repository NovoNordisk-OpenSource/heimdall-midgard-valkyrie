namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Domain;

public class IIntegrationEventToScaffoldTaskConverter(IMapper mapper, IScaffoldService ScaffoldService) : ITypeConverter<IIntegrationEvent, ScaffoldTask>
{
    public readonly IMapper _mapper = mapper;

    public readonly IScaffoldService _ScaffoldService = ScaffoldService ?? throw new ArgumentNullException(nameof(ScaffoldService));

    /// <summary>
    /// Converts an externally mutated scaffold task integration event to a scaffold task.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination scaffold task.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted scaffold task.</returns>
    public ScaffoldTask Convert(IIntegrationEvent source, ScaffoldTask destination, ResolutionContext context)
    {
        // Simplistic conversion logic
        JsonElement? payload;

        if (source?.Payload?.ValueKind == JsonValueKind.Object)
        {
            payload = source.Payload;
        }
        else
        {
            switch (source?.Payload?.ValueKind)
            {
                case JsonValueKind.String:
                    var rawText = source.Payload.Value.GetRawText();
                    var cleanedText = rawText[1..^1].Replace("\\", "");

                    payload = JsonDocument.Parse(cleanedText).RootElement;

                    break;
                default:
                    throw new ApplicationFacadeException($"Unsupported ValueKind: {source?.Payload?.ValueKind}");
            }
        }

        if(Guid.TryParse(payload?.GetProperty("id").GetString(), out var entityId))
        {
            var getEntityTask = _ScaffoldService.GetScaffoldTaskByIdAsync(entityId);

            getEntityTask.Wait();

            destination = getEntityTask.Result ?? throw new ApplicationFacadeException($"Scaffold task with id {entityId} not found.");

            // TODO: Map the integration event payload (JsonObject) to the scaffold task (ScaffoldTask)
        }

        return destination;
    }
}
