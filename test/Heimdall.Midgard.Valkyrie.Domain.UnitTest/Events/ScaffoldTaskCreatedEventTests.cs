namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Events;

public class ScaffoldTaskCreatedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldTaskCreatedEvent sut;

        //Act
        sut = new ScaffoldTaskCreatedEvent(null);

        //Assert
        Assert.NotNull(sut);
        Assert.Null(sut.ScaffoldTask);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var scaffoldTask = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new ScaffoldTaskCreatedEvent(scaffoldTask);

        //Act
        var anotherEvent = new ScaffoldTaskCreatedEvent(scaffoldTask);

        //Assert
        Assert.True(sut.ScaffoldTask == scaffoldTask);
        Assert.True(anotherEvent.ScaffoldTask == scaffoldTask);
        Assert.False(sut.Equals(anotherEvent));
    }
}