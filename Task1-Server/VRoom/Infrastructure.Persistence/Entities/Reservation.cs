namespace Infrastructure.Persistence.Entities;

public class Reservation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    // Navigation property
    public User User { get; set; }
    public Room Room { get; set; }
    public ICollection<ReservationService> Services { get; set; }
}