namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class CreateScaffoldOptionCommandHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockService = new Mock<IScaffoldService>();
        var sut = new CreateScaffoldOptionCommandHandler(mockService.Object);

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
        var key = "key";
        var value = "value";
        var mockService = new Mock<IScaffoldService>();
        mockService.Setup(x => x.AddOrUpdateScaffoldOptionAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ScaffoldOption(key, value));
        var sut = new CreateScaffoldOptionCommandHandler(mockService.Object);

        //Act
        var result = await sut.Handle(new CreateScaffoldOptionCommand(Guid.NewGuid(), key, value));

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(key, result.Key); 
        Assert.Equal(value, result.Value);
    }
}