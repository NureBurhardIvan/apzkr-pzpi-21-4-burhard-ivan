using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking.DTOs.RequestDTOs;
using Application.Booking.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IBookingRepository
{
    public Task<BookingGotDto> Create(CreateBookingDto createBookingDto);

    public Task<List<BookingGotDto>> GetAllByUser(Guid userId);
}