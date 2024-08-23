using Application.Common.Interfaces.Repositories;
using Application.Hotel.DTOs.RequestDTOs;
using Application.Hotel.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _dbContext;

    public HotelRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<HotelGotDto> Create(CreateHotelDto createHotelDto)
    {
        var hotelToCreate = createHotelDto.CreateHotelToHotel();

        var hotel = (await _dbContext.Hotels.AddAsync(hotelToCreate)).Entity;
        await _dbContext.SaveChangesAsync();
        
        return hotel.HotelToHotelGot();
    }

    public async Task<List<HotelGotDto>> GetAll()
    {
        return await _dbContext.Hotels.Select(x => x.HotelToHotelGot()).ToListAsync();
    }
}