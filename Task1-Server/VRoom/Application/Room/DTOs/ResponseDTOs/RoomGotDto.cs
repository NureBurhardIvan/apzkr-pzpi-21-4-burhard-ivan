using System;
using Application.Enums;

namespace Application.Room.DTOs.ResponseDTOs;

public class RoomGotDto
{
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    public Occupation Occupation { get; set; }
    public decimal Rate { get; set; }
}