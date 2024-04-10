namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Events;

public class IIntegrationEventToScaffoldTaskConverter(IMapper mapper, IScaffoldService scaffoldService) : ITypeConverter<IIntegrationEvent, ValueTask<ScaffoldTask?>>
{
    public readonly IMapper _mapper = mapper;

    public readonly IScaffoldService _scaffoldService = scaffoldService ?? throw new ArgumentNullException(nameof(scaffoldService));

    /// <summary>
    /// Converts an externally mutated scaffold task integration event to a scaffold task.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination scaffold task.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted scaffold task.</returns>
    public async ValueTask<ScaffoldTask?> Convert(IIntegrationEvent source, ValueTask<ScaffoldTask?> destination, ResolutionContext context)
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
            destination = ValueTask.FromResult(await _scaffoldService.GetScaffoldTaskByIdAsync(entityId));
        }

        return await destination;
    }
}
