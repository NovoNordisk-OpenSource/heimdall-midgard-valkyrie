namespace Heimdall.Midgard.Valkyrie.Application.IntegrationTest.Mapping.Profiles;

public class DefaultProfileTests(ServiceProviderFixture fixture) : IClassFixture<ServiceProviderFixture>
{    
    private readonly ServiceProviderFixture _fixture = fixture;

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

    [Fact]
    public void CanMapIIntegrationEvent2ICommand()
    {
        //Arrange
        var sut = new DefaultProfile();
        var integrationEvent = new ScaffoldTaskCreatedIntegrationEvent()
        {
            Type = "externally_mutated_domain_entity_integration_event",
            Payload = JsonDocument.Parse("{\"scaffoldTask\":{\"scaffoldTaskId\":\"A39F9312-AFC8-41A6-A8EF-24F5235DC353\",\"options\":[],\"account\":{\"identifier\":\"default\",\"role\":\"default\"}}}").RootElement
        };
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.ConstructServicesUsing(_fixture.Provider.GetService);
            cfg.AddProfile(sut);
        }).CreateMapper();

        //Act
        var result = mapper.Map<ICommand<ScaffoldTask>>(integrationEvent);

        //Assert
        Assert.NotNull(result);
    }
}