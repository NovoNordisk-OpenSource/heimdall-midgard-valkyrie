namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters;

/// <summary>
/// Converts an integration event to an aggregate root using AutoMapper.
/// </summary>
public class IIntegrationEventToIAggregateRootConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, IAggregateRoot>
{
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Converts the specified integration event to an aggregate root.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination aggregate root.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted aggregate root.</returns>
    public IAggregateRoot Convert(IIntegrationEvent source, IAggregateRoot destination, ResolutionContext context)
    {
        return source.Type switch
        {
            "externally_mutated_domain_entity_integration_event" => _mapper.Map<ScaffoldTask>(source),
            _ => throw new NotSupportedException($"The integration event type {source.Type} is not supported.")
        };
    }
}
