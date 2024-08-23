using Application.Common.Interfaces.Repositories;
using Application.Room.DTOs.RequestDTOs;
using Application.Room.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RoomRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<RoomGotDto> Create(CreateRoomDto createRoomDto)
    {
        var room = createRoomDto.CreateRoomToRoom();

        var result = (await _dbContext.Rooms.AddAsync(room)).Entity;
        await _dbContext.SaveChangesAsync();

        return result.RoomToRoomGot();
    }

    public async Task<List<RoomGotDto>> GetAllByHotel(Guid hotelId)
    {
        var rooms = await _dbContext.Rooms.Where(x => x.HotelId == hotelId).ToListAsync();

        return rooms.Select(x => x.RoomToRoomGot()).ToList();
    }

    public async Task<List<RoomGotDto>> GetAll()
    {
        return await _dbContext.Rooms.Select(x => x.RoomToRoomGot()).ToListAsync();
    }
}