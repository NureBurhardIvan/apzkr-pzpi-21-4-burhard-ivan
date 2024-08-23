using System;

namespace Application.Hotel.DTOs.ResponseDTOs;

public class HotelGotDto
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    public int Rating { get; set; }
}