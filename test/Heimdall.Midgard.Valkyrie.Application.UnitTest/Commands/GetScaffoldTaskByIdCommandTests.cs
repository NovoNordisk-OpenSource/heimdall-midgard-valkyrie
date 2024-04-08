namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class GetScaffoldTaskByIdCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var id = Guid.NewGuid();
        var sut = new GetScaffoldTaskByIdCommand(id);

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
        var sut = new GetScaffoldTaskByIdCommand(Guid.NewGuid());

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        GetScaffoldTaskByIdCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<GetScaffoldTaskByIdCommand>("{\"scaffoldTaskId\":\"00000000-0000-0000-0000-000000000000\"}");

        //Assert
        Assert.NotNull(sut);
    }
}