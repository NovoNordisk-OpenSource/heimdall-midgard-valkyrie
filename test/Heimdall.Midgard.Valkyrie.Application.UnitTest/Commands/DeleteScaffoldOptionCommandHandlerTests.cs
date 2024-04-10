namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class DeleteScaffoldOptionCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new DeleteScaffoldOptionCommandHandler(mockService.Object);

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
        var id = Guid.NewGuid();
        var key = "key";
        var mockService = new Mock<IScaffoldService>();
        mockService.Setup(x => x.DeleteScaffoldOptionAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var sut = new DeleteScaffoldOptionCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new DeleteScaffoldOptionCommand(id, key));

        //Assert
        Assert.NotNull(sut);
        Assert.True(result);
    }
}