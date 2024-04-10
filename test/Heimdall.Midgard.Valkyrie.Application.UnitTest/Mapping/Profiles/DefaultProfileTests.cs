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

    // [Fact]
    // public void CanMapIIntegrationEvent2ICommand()
    // {
    //     //Arrange
    //     var sut = new DefaultProfile();
    //     var integrationEvent = new ScaffoldTaskCreatedIntegrationEvent()
    //     {
    //         Payload = JsonDocument.Parse("{\"scaffoldTaskId\":\"b59bc2ad-4318-4000-960c-ac25e314448d\"}").RootElement
    //     };
    //     var mapper = new MapperConfiguration(cfg =>
    //     {
    //         //TODO: Move to IntegrationTest and inject the services so we can test the actual mapping
    //         cfg.AddProfile(sut);
    //     }).CreateMapper();

    //     //Act
    //     var result = mapper.Map<IIntegrationEvent, ICommand<IAggregateRoot>>(integrationEvent);

    //     //Assert
    //     Assert.NotNull(result);
    // }
}