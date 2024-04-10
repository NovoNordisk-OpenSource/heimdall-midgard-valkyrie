namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class DeleteScaffoldTaskCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new DeleteScaffoldTaskCommandHandler(mockService.Object);

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
        mockService.Setup(x => x.DeleteScaffoldTaskAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var sut = new DeleteScaffoldTaskCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new DeleteScaffoldTaskCommand(Guid.NewGuid()));

        //Assert
        Assert.NotNull(sut);
        Assert.True(result);
    }
}