using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Room.DTOs.RequestDTOs;
using Application.Room.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IRoomRepository
{
    public Task<RoomGotDto> Create(CreateRoomDto createHotelDto);
    
    public Task<List<RoomGotDto>> GetAllByHotel(Guid hotelId);
    
    public Task<List<RoomGotDto>> GetAll();
}