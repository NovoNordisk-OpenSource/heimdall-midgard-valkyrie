namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Mapping.Profiles;

public class DefaultProfileTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var sut = new DefaultProfile();

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());
    }
}