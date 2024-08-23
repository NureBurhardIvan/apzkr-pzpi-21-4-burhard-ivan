using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Hotel.DTOs.RequestDTOs;
using Application.Hotel.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IHotelRepository
{
    public Task<HotelGotDto> Create(CreateHotelDto createHotelDto);
    
    public Task<List<HotelGotDto>> GetAll();
}