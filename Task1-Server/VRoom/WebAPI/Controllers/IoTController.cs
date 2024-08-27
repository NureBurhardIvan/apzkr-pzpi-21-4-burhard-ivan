using Application.Common.Interfaces.Repositories;
using Application.IoT.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class IoTController: BaseApiController
{
    private IIoTRepository _ioTRepository;
    public IoTController(IIoTRepository serviceRepository)
    {
        _ioTRepository = serviceRepository;
    }

    [HttpPost]
    public async Task<IActionResult> SendData(SendIoTDataDto sendIoTDataDto)
    {
        await _ioTRepository.SendIoTData(sendIoTDataDto);
        return Ok();
    }
}