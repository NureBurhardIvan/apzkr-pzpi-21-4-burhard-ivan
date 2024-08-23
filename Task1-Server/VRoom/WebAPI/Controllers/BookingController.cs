using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Application.Hotel.DTOs.RequestDTOs;
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
    public async Task<IActionResult> Create(CreateHotelDto createHotelDto)
    {
        await _hotelRepository.Create(createHotelDto);

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _hotelRepository.GetAll();

        return Ok(result);
    }
}