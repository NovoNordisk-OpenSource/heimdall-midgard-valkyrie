namespace Heimdall.Midgard.Valkyrie.Application.IntegrationTest.Mapping.Profiles;

public class DefaultProfileTests(ServiceProviderFixture fixture) : IClassFixture<ServiceProviderFixture>
{    
    private readonly ServiceProviderFixture _fixture = fixture;

    [Fact]
    public async void CanMapIIntegrationEvent2ICommand()
    {
        //Arrange
        var sut = new DefaultProfile();
        var integrationEvent = new ScaffoldTaskCreatedIntegrationEvent()
        {
            Type = "externally_mutated_domain_entity_integration_event",
            Payload = JsonDocument.Parse("{\"scaffoldTaskId\":\"b59bc2ad-4318-4000-960c-ac25e314448d\"}").RootElement
        };
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.ConstructServicesUsing(_fixture.Provider.GetService);
            cfg.AddProfile(sut);
        }).CreateMapper();

        //Act
        var result = await mapper.Map<ValueTask<ScaffoldTask>>(integrationEvent);

        //Assert
        Assert.NotNull(result);
    }
}