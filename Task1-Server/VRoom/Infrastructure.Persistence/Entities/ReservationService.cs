namespace Infrastructure.Persistence.Entities;

public class ReservationService
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ReservationId { get; set; }
    public Guid ServiceId { get; set; }
    
    public Service Service { get; set; }
    public Reservation Reservation { get; set; }
}