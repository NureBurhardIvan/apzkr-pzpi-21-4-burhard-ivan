using Application.Service.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IStatRepository
{
    public TimeSpan GetAverageRoomTime();

    public Task<List<ServiceStatistics>> Get10MostPopularServices();
}