using Application.Common.Interfaces.Repositories;
using Application.IoT.DTOs.RequestDTOs;

namespace Infrastructure.Persistence.Repositories;

public class IoTRepository: IIoTRepository
{
    public Task SendIoTData(SendIoTDataDto sendIoTDataDto)
    {
        throw new NotImplementedException();
    }
}