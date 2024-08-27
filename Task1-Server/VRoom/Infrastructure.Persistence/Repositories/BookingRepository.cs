using Application.Booking.DTOs.RequestDTOs;
using Application.Booking.DTOs.ResponseDTOs;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BookingRepository: IBookingRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookingRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<BookingGotDto> Create(CreateBookingDto createBookingDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BookingGotDto>> GetAllByUser(Guid userId)
    {
        var result = await _dbContext.Bookings
            .Where(b => b.UserId == userId)
            .Select(x => x.BookingToBookingDto())
            .ToListAsync();
        return result;
    }

    public Task<List<BookingGotDto>> GetAll()
    {
        throw new NotImplementedException();
    }
}