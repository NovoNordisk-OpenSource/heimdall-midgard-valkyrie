namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Aggregates;

public class ScaffoldTaskStatusTests
{
    [Fact]
    public void CanBeConstructed()
    {
        var sut = new ScaffoldTaskStatus(1, "Created");

        Assert.NotNull(sut);
        Assert.True(sut.Id == 1 && sut.Name == "Created");
    }
}