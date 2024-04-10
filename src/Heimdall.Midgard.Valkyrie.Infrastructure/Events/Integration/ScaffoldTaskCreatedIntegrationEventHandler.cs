namespace Heimdall.Midgard.Valkyrie.Infrastructure.Events.Integration;

/// <summary>
///     Handles the integration event when a scaffold task is created.
/// </summary>
[AsyncApi]
public class ScaffoldTaskCreatedIntegrationEventHandler(IProducer<Ignore, IIntegrationEvent> producer) : IEventHandler<ScaffoldTaskCreatedIntegrationEvent>
{
    private readonly Counter<int> _eventCounter = Metrics.EventMeter.CreateCounter<int>("event.counter", description: "Counts the number of events processed by the handler");

    private readonly IProducer<Ignore, IIntegrationEvent> _producer = producer;

    /// <summary>
    ///     Handles the scaffold task created integration event.
    /// </summary>
    /// <param name="notification">The integration event notification.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns> 
    [Channel($"publish/{nameof(ScaffoldTaskCreatedIntegrationEvent)}")]
    [PublishOperation(typeof(ScaffoldTaskCreatedIntegrationEvent), Summary = "Produces ScaffoldTask integration events for external consumption.")]
    public async Task Handle(ScaffoldTaskCreatedIntegrationEvent notification, CancellationToken ct = default)
    {
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}",
            MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _eventCounter.Add(1);

        // Create topic if it does not exist
        using (var adminClient = new DependentAdminClientBuilder(_producer.Handle).Build())
        {
            var metaData = adminClient.GetMetadata(TimeSpan.FromSeconds(5));
            var topicInfo = metaData.Topics.Where(tp => string.Equals(nameof(ScaffoldTaskCreatedIntegrationEvent), tp.Topic, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (topicInfo == null)
                await adminClient.CreateTopicsAsync([new TopicSpecification { Name = nameof(ScaffoldTaskCreatedIntegrationEvent), ReplicationFactor = 1, NumPartitions = 1 }]);
        }

        // Produce message to topic
        await _producer.ProduceAsync(nameof(ScaffoldTaskCreatedIntegrationEvent), new Message<Ignore, IIntegrationEvent> { Value = notification }, ct);
    }
}