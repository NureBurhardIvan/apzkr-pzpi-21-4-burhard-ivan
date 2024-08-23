namespace Infrastructure.Persistence.Entities;

public class IoTData
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid RoomId { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
    public string OtherMetrics { get; set; }

    // Navigation property
    public Room Room { get; set; }
}