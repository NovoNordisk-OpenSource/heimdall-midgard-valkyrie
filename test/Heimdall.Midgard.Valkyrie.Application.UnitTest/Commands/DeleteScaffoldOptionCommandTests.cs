namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class DeleteScaffoldOptionCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var key = "key";
        var id = Guid.NewGuid();
        var sut = new DeleteScaffoldOptionCommand(id, key);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(key, sut.Key); 
        Assert.Equal(id, sut.ScaffoldTaskId);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new DeleteScaffoldOptionCommand(Guid.NewGuid(), "key");

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        DeleteScaffoldOptionCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<DeleteScaffoldOptionCommand>("{\"key\":\"key\",\"scaffoldTaskId\":\"00000000-0000-0000-0000-000000000000\"}");

        //Assert
        Assert.NotNull(sut);
    }
}