namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class UpdateScaffoldOptionCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var key = "key";
        var value = "value";
        var id = Guid.NewGuid();
        var sut = new UpdateScaffoldOptionCommand(id, key, value);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(key, sut.Key); 
        Assert.Equal(value, sut.Value);
        Assert.Equal(id, sut.ScaffoldTaskId);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new UpdateScaffoldOptionCommand(Guid.NewGuid(), "key", "value");

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        UpdateScaffoldOptionCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<UpdateScaffoldOptionCommand>("{\"key\":\"key\",\"value\":\"value\",\"scaffoldTaskId\":\"00000000-0000-0000-0000-000000000000\"}");

        //Assert
        Assert.NotNull(sut);
    }
}