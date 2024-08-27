namespace Application.IoT.DTOs.RequestDTOs;

public class SendIoTDataDto
{
    public Guid RoomId { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
    public string OtherMetrics { get; set; }
}