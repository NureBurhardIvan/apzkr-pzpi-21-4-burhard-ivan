using Application.Common.Interfaces.Repositories;
using Application.Service.DTOs.RequestDTOs;
using Application.Service.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ServiceRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ServiceGotDto> Create(CreateServiceDto createServiceDto)
    {
        var serviceToCreate = createServiceDto.CreateServiceToService();

        var service = (await _dbContext.Services.AddAsync(serviceToCreate)).Entity;
        await _dbContext.SaveChangesAsync();

        return service.ServiceToServiceGot();
    }

    public async Task<List<ServiceGotDto>> GetAll()
    {
        return await (_dbContext.Services.Select(x => x.ServiceToServiceGot())).ToListAsync();
    }
}