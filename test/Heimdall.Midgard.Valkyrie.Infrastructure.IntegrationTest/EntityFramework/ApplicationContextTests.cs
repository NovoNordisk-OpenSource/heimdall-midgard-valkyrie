namespace Heimdall.Midgard.Valkyrie.Infrastructure.IntegrationTest.EntityFramework;

public class ApplicationContextTests : IClassFixture<ApplicationContextFixture>
{
    private readonly ApplicationContextFixture _fixture;

    public ApplicationContextTests(ApplicationContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void CanBeConstructed()
    {
        // Arrange
        var sut = _fixture.GetDbContext();

        // Act
        var hashCode = sut.GetType().GetHashCode();

        // Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetType().GetHashCode());
    }

    [Fact]
    public async Task CanPublishDomainEventsOnSaveEntities()
    {
        //Arrange
        var entityToAdd = new ScaffoldTask(new AccountInfo(Guid.NewGuid().ToString(), "default"));
        var mockMediator = new Mock<IMediator>();

        mockMediator.Setup(m => m.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()));

        var sut = _fixture.GetDbContext(mockMediator.Object);

        //Act
        var attachedEntity = await sut.AddAsync(entityToAdd);
        bool result1 = await sut.SaveEntitiesAsync(new CancellationToken());

        sut.Remove(attachedEntity.Entity.Account);
        sut.Remove(attachedEntity.Entity.Status);
        sut.Remove(attachedEntity.Entity);

        bool result2 = await sut.SaveEntitiesAsync(new CancellationToken());

        //Assert
        Assert.NotNull(sut);
        Assert.True(result1);
        Assert.True(result2);
        Assert.True(attachedEntity.Entity.Id != Guid.Empty);

        Mock.VerifyAll();
    }
}