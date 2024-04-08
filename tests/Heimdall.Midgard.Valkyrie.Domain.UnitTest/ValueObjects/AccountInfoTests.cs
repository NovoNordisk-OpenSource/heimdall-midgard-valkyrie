namespace Heimdall.Midgard.Valkyrie.Domain.ValueObjects;

public class AccountInfoTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        AccountInfo sut;

        //Act
        sut = new AccountInfo("identifier", "role");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("identifier", sut.Identifier);
        Assert.Equal("role", sut.Role);
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new AccountInfo("identifier", "role");

        //Act
        var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        //Assert
        Assert.NotNull(JsonDocument.Parse(payload));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        AccountInfo sut;

        //Act
        sut = JsonSerializer.Deserialize<AccountInfo>("{\"identifier\":\"identifier\",\"role\":\"role\"}");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("identifier", sut.Identifier);
        Assert.Equal("role", sut.Role);
    }
}