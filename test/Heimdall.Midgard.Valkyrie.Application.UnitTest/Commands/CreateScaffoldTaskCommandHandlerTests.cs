namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class CreateScaffoldTaskCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new CreateScaffoldTaskCommandHandler(mockService.Object);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public async void CanHandleCommand()
    {
        //Arrange        
        var account = new AccountInfo("default", "default");
        var options = new List<ScaffoldOption> { new("key", "value") };
        var mockService = new Mock<IScaffoldService>();
        mockService.Setup(x => x.AddScaffoldTaskAsync(It.IsAny<AccountInfo>(), It.IsAny<IEnumerable<ScaffoldOption>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ScaffoldTask(account, options));
        var sut = new CreateScaffoldTaskCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new CreateScaffoldTaskCommand(account, options));

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(account, result.Account); 
        Assert.Equal(options, result.Options);
    }
}