namespace Heimdall.Midgard.Valkyrie.Application.Events.Domain;

/// <summary>
///     Represents an event handler for the <see cref="ScaffoldTaskCreatedEvent" /> event.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="ScaffoldTaskCreatedEventHandler" /> class.
/// </remarks>
/// <param name="mapper">The AutoMapper instance.</param>
/// <param name="mediator">The MediatR instance.</param>
public sealed class ScaffoldTaskCreatedEventHandler(IMapper mapper, IMediator mediator) : IEventHandler<ScaffoldTaskCreatedEvent>
{
    private readonly IMapper _mapper = mapper;

    private readonly IMediator _mediator = mediator;

    /// <summary>
    ///     Handles the <see cref="ScaffoldTaskCreatedEvent" /> event.
    /// </summary>
    /// <param name="event">The event to handle.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ScaffoldTaskCreatedEvent @event, CancellationToken ct = default)
    {
        await _mediator.Publish(_mapper.Map<ScaffoldTaskCreatedIntegrationEvent>(@event), ct);
    }
}