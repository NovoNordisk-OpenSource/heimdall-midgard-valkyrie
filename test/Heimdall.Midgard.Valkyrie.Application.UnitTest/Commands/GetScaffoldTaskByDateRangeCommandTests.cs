namespace Heimdall.Midgard.Valkyrie.Application.UnitTest.Events.Domain;

public class GetScaffoldTaskByDateRangeCommandTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var now = DateTime.Now;
        var sut = new GetScaffoldTaskByDateRangeCommand(now, now.AddDays(1));

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(now, sut.StartDate);
        Assert.Equal(now, sut.EndDate?.AddDays(-1));
        Assert.Equal(hashCode, sut.GetHashCode());
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var now = DateTime.Now;
        var sut = new GetScaffoldTaskByDateRangeCommand(now, now.AddDays(1));

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        GetScaffoldTaskByDateRangeCommand sut;

        //Act
        sut = JsonSerializer.Deserialize<GetScaffoldTaskByDateRangeCommand>("{\"startDate\":\"2024-04-08T15:31:39.4643913+02:00\",\"endDate\":\"2024-04-09T15:31:39.4643913+02:00\"}");

        //Assert
        Assert.NotNull(sut);
    }
}