namespace Infrastructure.Persistence.Entities;

public class Room
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid HotelId { get; set; }
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    public Occupation Occupation { get; set; } = Occupation.Free;
    public decimal Rate { get; set; }

    // Navigation property
    public Hotel Hotel { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<IoTData> IoTData { get; set; }
}