namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Events;

public class ScaffoldTaskCompletedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldTaskCompletedEvent sut;

        //Act
        sut = new ScaffoldTaskCompletedEvent(null);

        //Assert
        Assert.NotNull(sut);
        Assert.Null(sut.ScaffoldTask);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var scaffoldTask = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new ScaffoldTaskCompletedEvent(scaffoldTask);

        //Act
        var anotherEvent = new ScaffoldTaskCompletedEvent(scaffoldTask);

        //Assert
        Assert.True(sut.ScaffoldTask == scaffoldTask);
        Assert.True(anotherEvent.ScaffoldTask == scaffoldTask);
        Assert.False(sut.Equals(anotherEvent));
    }
}