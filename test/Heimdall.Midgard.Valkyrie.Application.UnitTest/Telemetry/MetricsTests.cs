namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class MetricsTests
{
    [Fact]
    public void IsValid()
    {
        //Assert
        Assert.Equal("application.requests", Metrics.RequestMeter.Name);
        Assert.Equal("application.events", Metrics.EventMeter.Name);
    }
}