namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class DeleteScaffoldTaskCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var id = Guid.NewGuid();
        var sut = new DeleteScaffoldTaskCommand(id);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(id, sut.ScaffoldTaskId);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new DeleteScaffoldTaskCommand(Guid.NewGuid());

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        DeleteScaffoldTaskCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<DeleteScaffoldTaskCommand>("{\"scaffoldTaskId\":\"00000000-0000-0000-0000-000000000000\"}");

        //Assert
        Assert.NotNull(sut);
    }
}