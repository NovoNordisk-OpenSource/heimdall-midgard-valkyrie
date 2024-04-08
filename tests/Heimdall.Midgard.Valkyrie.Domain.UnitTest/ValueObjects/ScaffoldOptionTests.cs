namespace Heimdall.Midgard.Valkyrie.Domain.ValueObjects;

public class ScaffoldOptionTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldOption sut;

        //Act
        sut = new ScaffoldOption("key", "value");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("key", sut.Key);
        Assert.Equal("value", sut.Value);
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new ScaffoldOption("key", "value");

        //Act
        var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        //Assert
        Assert.NotNull(JsonDocument.Parse(payload));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        ScaffoldOption sut;

        //Act
        sut = JsonSerializer.Deserialize<ScaffoldOption>("{\"key\":\"key\",\"value\":\"value\"}");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("key", sut.Key);
        Assert.Equal("value", sut.Value);
    }
}