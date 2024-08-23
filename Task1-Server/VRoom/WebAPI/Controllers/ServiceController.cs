using Application.Common.Interfaces.Repositories;
using Application.Service.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class ServiceController : BaseApiController
{
    private IServiceRepository _serviceRepository;
    public ServiceController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
    {
        var result = await _serviceRepository.Create(createServiceDto);

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _serviceRepository.GetAll();

        return Ok(result);
    }
}