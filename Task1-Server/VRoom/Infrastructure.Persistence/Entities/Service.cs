namespace Infrastructure.Persistence.Entities;

public class Service
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }

    // Navigation property
    public ICollection<ReservationService> Reservations { get; set; }
}