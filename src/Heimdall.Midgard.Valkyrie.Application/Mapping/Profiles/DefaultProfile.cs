namespace Heimdall.Midgard.Valkyrie.Application.Mapping.Profiles;

/// <summary>
///     Represents the default AutoMapper profile for mapping entities in the application.
/// </summary>
public sealed class DefaultProfile : Profile
{
    public DefaultProfile()
    {
        CreateMap<IAggregateRoot, ICommand<IAggregateRoot>>()
        .ConvertUsing<IAggregateRootToICommandConverter>();

        CreateMap<IIntegrationEvent, IAggregateRoot>()
        .ConvertUsing<IIntegrationEventToIAggregateRootConverter>();

        CreateMap<IIntegrationEvent, ValueTask<ScaffoldTask?>>()
        .ConvertUsing<IIntegrationEventToScaffoldTaskConverter>();
    }
}