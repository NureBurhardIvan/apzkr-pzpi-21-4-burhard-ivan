using Application.Common.Interfaces.Repositories;
using Application.Service.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class StatRepository : IStatRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StatRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public TimeSpan GetAverageRoomTime()
    {
        var timespan = TimeSpan.FromSeconds(
            _dbContext.Bookings
                .Select(x => (x.CheckOutDate - x.CheckInDate).TotalSeconds)
                .Average());
        return timespan;
    }

    public async Task<List<ServiceStatistics>> Get10MostPopularServices()
    {
        var topServices = await _dbContext.ReservationServices
            .GroupBy(rs => rs.Service)
            .Select(group => new ServiceStatistics
            {
                ServiceName = group.Key.Name,
                ReservationCount = group.Count()
            })
            .OrderByDescending(s => s.ReservationCount)
            .Take(10)
            .ToListAsync();
        return topServices;
    }
}