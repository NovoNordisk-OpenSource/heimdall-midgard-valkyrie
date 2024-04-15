namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class UpdateScaffoldTaskCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var entity = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new UpdateScaffoldTaskCommand(entity.Id, entity.Account, entity.Options);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);        
        Assert.Equal(entity.Id, sut.ScaffoldTaskId);
        Assert.Equal(entity.Account, sut.Account);
        Assert.Equal(entity.Options, sut.Options);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var entity = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new UpdateScaffoldTaskCommand(entity.Id, entity.Account, entity.Options);

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        UpdateScaffoldTaskCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<UpdateScaffoldTaskCommand>("{\"scaffoldTaskId\":\"A39F9312-AFC8-41A6-A8EF-24F5235DC353\",\"options\":[],\"account\":{\"identifier\":\"default\",\"role\":\"default\"}}");

        //Assert
        Assert.NotNull(sut);
    }
}