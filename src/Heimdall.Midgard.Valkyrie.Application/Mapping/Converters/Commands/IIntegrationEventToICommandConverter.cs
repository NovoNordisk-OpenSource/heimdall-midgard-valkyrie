namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Commands;

/// <summary>
/// Converts an integration event to a command using AutoMapper.
/// </summary>
public class IIntegrationEventToICommandConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, ICommand<IAggregateRoot>>
{
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Converts an integration event to a command using AutoMapper.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination command object.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted command object.</returns>
    public ICommand<IAggregateRoot> Convert(IIntegrationEvent source, ICommand<IAggregateRoot> destination, ResolutionContext context)
    {
        return _mapper.Map(source, destination);
    }
}
