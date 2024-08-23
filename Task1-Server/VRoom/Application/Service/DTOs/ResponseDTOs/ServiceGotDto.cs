using System;

namespace Application.Service.DTOs.ResponseDTOs;

public class ServiceGotDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}