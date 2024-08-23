using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Service.DTOs.RequestDTOs;
using Application.Service.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IServiceRepository
{
    public Task<ServiceGotDto> Create(CreateServiceDto createHotelDto);
    
    public Task<List<ServiceGotDto>> GetAll();
}