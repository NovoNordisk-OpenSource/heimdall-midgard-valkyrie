namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Events;

public class ScaffoldTaskQueuedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldTaskQueuedEvent sut;

        //Act
        sut = new ScaffoldTaskQueuedEvent(null);

        //Assert
        Assert.NotNull(sut);
        Assert.True(sut.Entity == null);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var scaffoldTask = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new ScaffoldTaskQueuedEvent(scaffoldTask);

        //Act
        var anotherEvent = new ScaffoldTaskQueuedEvent(scaffoldTask);

        //Assert
        Assert.True(sut.Entity == scaffoldTask);
        Assert.True(anotherEvent.Entity == scaffoldTask);
        Assert.False(sut.Equals(anotherEvent));
    }
}