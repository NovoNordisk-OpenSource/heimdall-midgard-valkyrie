namespace Heimdall.Midgard.Valkyrie.Application.IntegrationTest;

public class ApplicationFacadeTests(ServiceProviderFixture serviceProviderFixture) : IClassFixture<ServiceProviderFixture>
{
    private readonly ServiceProviderFixture _serviceProviderFixture = serviceProviderFixture;

    [Fact]
    public async Task CanProcessCommand()
    {
        //Arrange
        var sut = _serviceProviderFixture.Provider.GetService<IApplicationFacade>();
        var testCommand = new CreateScaffoldTaskCommand(new AccountInfo("default", "default"), []);

        //Act
        var result = await sut.Execute(testCommand);

        //Assert
        Assert.NotNull(result);
    }
}