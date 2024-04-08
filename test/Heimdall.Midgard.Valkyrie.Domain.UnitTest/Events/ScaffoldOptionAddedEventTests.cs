namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Events;

public class ScaffoldOptionAddedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldOptionAddedEvent sut;

        //Act
        sut = new ScaffoldOptionAddedEvent(null, null);

        //Assert
        Assert.NotNull(sut);
        Assert.Null(sut.ScaffoldTask);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var scaffoldTask = new ScaffoldTask(new AccountInfo("default", "default"));
        var scaffoldOption = new ScaffoldOption("default", "default");
        var sut = new ScaffoldOptionAddedEvent(scaffoldTask, scaffoldOption);

        //Act
        var anotherEvent = new ScaffoldOptionAddedEvent(scaffoldTask, scaffoldOption);

        //Assert
        Assert.True(sut.ScaffoldTask == scaffoldTask);
        Assert.True(sut.Option == scaffoldOption);
        Assert.True(anotherEvent.ScaffoldTask == scaffoldTask);
        Assert.True(anotherEvent.Option == scaffoldOption);
        Assert.False(sut.Equals(anotherEvent));
    }
}