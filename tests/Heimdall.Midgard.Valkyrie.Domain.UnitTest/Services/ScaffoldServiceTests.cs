namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Services;

public class ScaffoldServiceTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldService sut;
        var scaffoldTaskRepository = new Mock<IScaffoldTaskRepository>();

        //Act
        sut = new ScaffoldService(scaffoldTaskRepository.Object);

        //Assert
        Assert.NotNull(sut);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanAddScaffoldTask()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IScaffoldTaskRepository>();
        var fakeAggregate = new ScaffoldTask(new AccountInfo("default", "default"));

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.Add(It.IsAny<ScaffoldTask>())).Returns(fakeAggregate);

        var sut = new ScaffoldService(mockRepository.Object);

        //Act
        var result = await sut.AddScaffoldTaskAsync(new AccountInfo("identifier", "role"));

        //Assert
        Assert.NotNull(result);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeleteScaffoldTask()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IScaffoldTaskRepository>();
        var fakeAggregate = new ScaffoldTask(new AccountInfo("default", "default"));

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<ScaffoldTask>()));

        var sut = new ScaffoldService(mockRepository.Object);

        //Act
        await sut.DeleteScaffoldTaskAsync(Guid.NewGuid());

        //Assert
        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeleteScaffoldOption()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IScaffoldTaskRepository>();
        var fakeAggregate = new ScaffoldTask(new AccountInfo("default", "default"));

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<ScaffoldTask>()));

        var sut = new ScaffoldService(mockRepository.Object);

        //Act
        await sut.DeleteScaffoldOptionAsync(fakeAggregate.Id, "option-key");

        //Assert
        Mock.VerifyAll();
    }
}