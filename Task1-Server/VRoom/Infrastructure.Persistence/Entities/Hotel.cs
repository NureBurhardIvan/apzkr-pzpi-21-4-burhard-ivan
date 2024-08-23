namespace Infrastructure.Persistence.Entities;

public class Hotel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Rating { get; set; }

    // Navigation properties
    public ICollection<Room> Rooms { get; set; }
}