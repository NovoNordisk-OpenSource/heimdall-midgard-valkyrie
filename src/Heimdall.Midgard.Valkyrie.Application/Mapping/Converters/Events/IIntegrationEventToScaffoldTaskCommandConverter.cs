namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Events;

public class IIntegrationEventToScaffoldTaskCommandConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, ICommand<ScaffoldTask>>
{
    public readonly IMapper _mapper = mapper;

    /// <summary>
    /// Converts an externally mutated scaffold task integration event to a scaffold task command.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination command.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted scaffold task.</returns>
    public ICommand<ScaffoldTask> Convert(IIntegrationEvent source, ICommand<ScaffoldTask> destination, ResolutionContext context)
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

        if(payload?.TryGetProperty("scaffoldTask", out var scaffoldTaskJson) is true){
            var scaffoldTaskId = scaffoldTaskJson.GetProperty("scaffoldTaskId").GetGuid();
            var account = scaffoldTaskJson.GetProperty("account").Deserialize<AccountInfo>();
            var options = scaffoldTaskJson.GetProperty("options").Deserialize<IEnumerable<ScaffoldOption>>();

            if(account is null || options is null)
            {
                throw new ApplicationFacadeException("Invalid payload");
            }

            destination = (scaffoldTaskId != Guid.Empty) ? new UpdateScaffoldTaskCommand(scaffoldTaskId, account, options) : new CreateScaffoldTaskCommand(account, options);
        };

        return destination;
    }
}
