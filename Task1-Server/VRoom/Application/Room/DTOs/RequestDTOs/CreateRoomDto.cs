using System;
using Application.Enums;

namespace Application.Room.DTOs.RequestDTOs;

public class CreateRoomDto
{
    public Guid Id { get; set; } = new Guid();
    public Guid HotelId { get; set; }
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    public Occupation Occupation { get; set; }
    public decimal Rate { get; set; }
}