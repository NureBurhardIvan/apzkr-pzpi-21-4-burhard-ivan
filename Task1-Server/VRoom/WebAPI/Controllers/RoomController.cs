using Application.Common.Interfaces.Repositories;
using Application.Hotel.DTOs.RequestDTOs;
using Application.Room.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[AllowAnonymous]
public class RoomController : BaseApiController
{
    private IRoomRepository _roomRepository;
    public RoomController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomDto createRoomDto)
    {
        await _roomRepository.Create(createRoomDto);

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roomRepository.GetAll();

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByHotel(Guid hotelId)
    {
        var result = await _roomRepository.GetAllByHotel(hotelId);

        return Ok(result);
    }
}