namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class ScaffoldTaskCreatedEventHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var sut = new ScaffoldTaskCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanHandleEvent()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var entity = new ScaffoldTask(new AccountInfo("default", "default"));
        var sut = new ScaffoldTaskCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        await sut.Handle(new ScaffoldTaskCreatedEvent(entity));

        //Assert
        Mock.VerifyAll();
    }
}