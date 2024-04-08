namespace Heimdall.Midgard.Valkyrie.Domain.UnitTest.Events;

public class ScaffoldTaskCreatedIntegrationEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        ScaffoldTaskCreatedIntegrationEvent sut;
        var creationDate = DateTime.UtcNow;
        var payload = JsonDocument.Parse(JsonSerializer.Serialize(new object())).RootElement;

        //Act
        sut = new ScaffoldTaskCreatedIntegrationEvent(){
            Id = "id",
            CorrelationId = "correlationId",
            CreationDate = creationDate,
            SchemaVersion = "schemaVersion",
            Type = "type",
            Payload = payload
        };

        //Assert
        Assert.True(sut.Id == "id");
        Assert.True(sut.CorrelationId == "correlationId");
        Assert.True(sut.CreationDate.Equals(creationDate));
        Assert.True(sut.SchemaVersion == "schemaVersion");
        Assert.True(sut.Type == "type");
        Assert.True(sut.Payload.Equals(payload));
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var payload = JsonDocument.Parse(JsonSerializer.Serialize(new object())).RootElement;
        var sut = new ScaffoldTaskCreatedIntegrationEvent(){
            Id = "id",
            CorrelationId = "correlationId",
            CreationDate = DateTime.UtcNow,
            SchemaVersion = "schemaVersion",
            Type = "type",
            Payload = payload
        };

        //Act
        var result = JsonSerializer.Serialize(sut);

        //Assert
        Assert.NotNull(JsonDocument.Parse(result));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        ScaffoldTaskCreatedIntegrationEvent sut;

        //Act
        sut = JsonSerializer.Deserialize<ScaffoldTaskCreatedIntegrationEvent>("{\"id\":\"id\",\"correlationId\":\"correlationId\",\"schemaVersion\":\"schemaVersion\",\"type\":\"type\"}");

        //Assert
        Assert.NotNull(sut);
        Assert.True(sut.Id == "id");
        Assert.True(sut.CorrelationId == "correlationId");
        Assert.True(sut.SchemaVersion == "schemaVersion");
        Assert.True(sut.Type == "type");
    }
}