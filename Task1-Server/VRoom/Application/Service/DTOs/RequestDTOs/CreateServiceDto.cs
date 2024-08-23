namespace Application.Service.DTOs.RequestDTOs;

public class CreateServiceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}