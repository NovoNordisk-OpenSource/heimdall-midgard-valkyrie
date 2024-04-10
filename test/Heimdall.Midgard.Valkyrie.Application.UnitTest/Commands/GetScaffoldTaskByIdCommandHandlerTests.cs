namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class GetScaffoldTaskByIdCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new GetScaffoldTaskByIdCommandHandler(mockService.Object);

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
        var mockService = new Mock<IScaffoldService>();
        mockService.Setup(x => x.GetScaffoldTaskByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ScaffoldTask(new AccountInfo("default", "default"), [new("key", "value")]));
        var sut = new GetScaffoldTaskByIdCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new GetScaffoldTaskByIdCommand(Guid.NewGuid()));

        //Assert
        Assert.NotNull(sut);
        Assert.True(result.Account is not null);
        Assert.Equal("default", result.Account.Identifier);
        Assert.Equal("default", result.Account.Role);
        Assert.True(result.Options is not null);
        Assert.Single(result.Options);
        Assert.Equal("key", result.Options.First().Key);
        Assert.Equal("value", result.Options.First().Value);
    }
}