namespace Heimdall.Midgard.Valkyrie.Infrastructure.Kafka.Strategies;

/// <summary>
///     Represents a strategy for consuming generic integration events from Kafka.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="GenericIntegrationEventConsumptionStrategy" /> class.
/// </remarks>
/// <param name="mapper">The mapper used for object mapping.</param>
/// <param name="applicationFacade">The application facade for executing commands.</param>
public sealed class GenericIntegrationEventConsumptionStrategy(IMapper mapper, IApplicationFacade applicationFacade) : ConsumptionStrategy(mapper, applicationFacade)
{
    /// <summary>
    ///     Applies the consumption strategy to the specified Kafka message.
    /// </summary>
    /// <param name="target">The Kafka message to apply the strategy to.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public override async Task Apply(ConsumeResult<string, string> target, CancellationToken ct = default)
    {
        var payload = target.Message.Value;

        if (!string.IsNullOrEmpty(payload))
        {
            var @event = JsonSerializer.Deserialize<IntegrationEvent>(payload);
            var aggregate = _mapper.Map<IAggregateRoot>(@event);
            var command = _mapper.Map<ICommand<IAggregateRoot>>(aggregate);

            if (command != null) 
                await _applicationFacade.Execute(command, ct);
        }
    }
}