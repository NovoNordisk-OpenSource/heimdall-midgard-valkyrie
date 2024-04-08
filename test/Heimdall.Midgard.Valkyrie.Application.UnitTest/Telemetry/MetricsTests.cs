namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class MetricsTests
{
    [Fact]
    public void IsValid()
    {
        //Assert
        Assert.True(Metrics.RequestMeter.Name == "application.requests");
        Assert.True(Metrics.EventMeter.Name == "application.events");
    }
}