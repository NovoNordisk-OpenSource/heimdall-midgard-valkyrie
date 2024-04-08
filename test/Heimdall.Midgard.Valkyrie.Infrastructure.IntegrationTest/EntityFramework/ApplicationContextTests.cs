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
        var entityToAdd = new ScaffoldTask(new AccountInfo("default", "default"));
        var mockMediator = new Mock<IMediator>();

        mockMediator.Setup(m => m.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()));

        var sut = _fixture.GetDbContext(mockMediator.Object);

        //Act
        var attachedEntity = await sut.AddAsync(entityToAdd);
        bool result = await sut.SaveEntitiesAsync(new CancellationToken());

        //Assert
        Assert.NotNull(sut);
        Assert.True(result);
        Assert.True(attachedEntity.Entity.Id != Guid.Empty);

        Mock.VerifyAll();
    }
}