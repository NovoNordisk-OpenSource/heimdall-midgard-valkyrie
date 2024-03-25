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

        CreateMap<IIntegrationEvent, ICommand<IAggregateRoot>>()
        .ConvertUsing<IIntegrationEventToICommandConverter>();

        CreateMap<IIntegrationEvent, IAggregateRoot>()
        .ConvertUsing<IIntegrationEventToIAggregateRootConverter>();

        CreateMap<IIntegrationEvent, ScaffoldTask>()
        .ConvertUsing<IIntegrationEventToScaffoldTaskConverter>();
    }
}