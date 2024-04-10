namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Mapping.Profiles;

public class DefaultProfileTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var sut = new DefaultProfile();

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanMapIAggregateRoot2ICommand()
    {
        //Arrange
        var sut = new DefaultProfile();
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(sut);
        }).CreateMapper();

        //Act
        var result = mapper.Map<IAggregateRoot, ICommand<IAggregateRoot>>(new ScaffoldTask(new AccountInfo("test", "test")));

        //Assert
        Assert.NotNull(result);
        Assert.True(result is CreateScaffoldTaskCommand);
    }
}