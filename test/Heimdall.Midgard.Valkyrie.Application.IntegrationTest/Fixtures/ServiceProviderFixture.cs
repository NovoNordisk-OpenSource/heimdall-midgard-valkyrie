namespace Heimdall.Midgard.Valkyrie.Application.IntegrationTest.Fixtures;

public class ServiceProviderFixture : IDisposable
{
    public IServiceProvider Provider { get; init; }

    public ServiceProviderFixture()
    {
        var services = new ServiceCollection();
        var fakeResult = new ScaffoldTask(new AccountInfo("test", "test"));
        var mockUoW = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IScaffoldTaskRepository>();

        mockUoW.Setup(o => o.SaveEntitiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true);
        mockRepository.Setup(o => o.UnitOfWork).Returns(mockUoW.Object);        
        mockRepository.Setup(o => o.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(fakeResult);
        mockRepository.Setup(o => o.GetAsync(It.IsAny<Expression<Func<ScaffoldTask, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync([fakeResult]);

        services.AddTransient<IRepository<ScaffoldTask>>(provider => mockRepository.Object);
        services.AddTransient(provider => mockRepository.Object);

        services.AddApplication();       
        
        Provider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }
}
