namespace Application.Service.DTOs.RequestDTOs;

public class UpdateServiceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}