using Application.IoT.DTOs.RequestDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IIoTRepository
{
    public Task SendIoTData(SendIoTDataDto sendIoTDataDto);
}