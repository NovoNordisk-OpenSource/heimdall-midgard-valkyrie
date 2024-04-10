namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Aggregates;

public class ScaffoldTaskTests
{
    [Fact]
    public void CanBeConstructed()
    {
        var sut = new ScaffoldTask(new AccountInfo("default", "default"));

        Assert.NotNull(sut);
        Assert.Single(sut.DomainEvents);
        Assert.Contains(sut.DomainEvents, i => i is ScaffoldTaskCreatedEvent);
    }

    [Fact]
    public void CanDetectValidConstruction()
    {
        //Arrange
        var sut = new ScaffoldTask(new AccountInfo("default", "default"));
        var validationCtx = new ValidationContext(this);

        //Act
        var validationResults = sut.Validate(validationCtx);

        //Assert
        Assert.False(validationResults.Any());
    }
}