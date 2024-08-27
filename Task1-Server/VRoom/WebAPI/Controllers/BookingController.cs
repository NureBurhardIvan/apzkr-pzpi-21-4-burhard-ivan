using Application.Booking.DTOs.RequestDTOs;
using Application.Common.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class BookingController : BaseApiController
{
    private IBookingRepository _bookingRepository;
    public BookingController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingDto createBookingDto)
    {
        var res = await _bookingRepository.Create(createBookingDto);

        return Ok(res);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByUser(Guid userId)
    {
        var result = await _bookingRepository.GetAllByUser(userId);

        return Ok(result);
    }
}