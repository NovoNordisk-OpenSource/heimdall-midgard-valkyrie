namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class CreateScaffoldTaskCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var account = new AccountInfo("default", "default");
        var options = new List<ScaffoldOption>();
        var sut = new CreateScaffoldTaskCommand(account, options);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);        
        Assert.Equal(account, sut.Account);        
        Assert.Equal(options, sut.Options);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new CreateScaffoldTaskCommand(new AccountInfo("default", "default"), []);

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        CreateScaffoldTaskCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<CreateScaffoldTaskCommand>("{\"options\":[],\"account\":{\"identifier\":\"default\",\"role\":\"default\"}}");

        //Assert
        Assert.NotNull(sut);
    }
}