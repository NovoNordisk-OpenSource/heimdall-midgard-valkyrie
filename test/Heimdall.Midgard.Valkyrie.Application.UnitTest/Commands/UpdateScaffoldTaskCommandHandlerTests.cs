namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class UpdateScaffoldTaskCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new UpdateScaffoldTaskCommandHandler(mockService.Object);

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
        var scaffoldTask = new ScaffoldTask(account, options);
        var mockService = new Mock<IScaffoldService>();
        mockService.Setup(x => x.GetScaffoldTaskByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(scaffoldTask);
        mockService.Setup(x => x.UpdateScaffoldTaskAsync(It.IsAny<ScaffoldTask>(), It.IsAny<CancellationToken>())).ReturnsAsync(scaffoldTask);
        var sut = new UpdateScaffoldTaskCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new UpdateScaffoldTaskCommand(Guid.NewGuid(), account, options));

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(scaffoldTask.Account.Identifier, result.Account.Identifier);
        Assert.Equal(scaffoldTask.Account.Role, result.Account.Role);
        Assert.Equal(scaffoldTask.Options, result.Options);
    }
}