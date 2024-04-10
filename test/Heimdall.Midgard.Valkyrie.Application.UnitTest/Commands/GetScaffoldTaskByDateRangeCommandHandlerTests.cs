namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class GetScaffoldTaskByDateRangeCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new GetScaffoldTaskByDateRangeCommandHandler(mockService.Object);

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
        mockService.Setup(x => x.GetScaffoldTaskByDateRangeAsync(It.IsAny<DateTime>(), It.IsAny<DateTime?>(), It.IsAny<CancellationToken>())).ReturnsAsync([new ScaffoldTask(new AccountInfo("default", "default"), [new("key", "value")])] );
        var sut = new GetScaffoldTaskByDateRangeCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new GetScaffoldTaskByDateRangeCommand(DateTime.Now));

        //Assert
        Assert.NotNull(sut);
        Assert.True(result.Any());
    }
}