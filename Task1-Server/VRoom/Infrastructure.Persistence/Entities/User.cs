namespace Infrastructure.Persistence.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public Role Role { get; set; } = Role.User;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Passport { get; set; }

    // Navigation property
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}