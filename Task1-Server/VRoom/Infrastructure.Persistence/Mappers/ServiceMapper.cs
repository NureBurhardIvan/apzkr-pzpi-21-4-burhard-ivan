using Application.Service.DTOs.RequestDTOs;
using Application.Service.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Persistence.Mappers;

[Mapper]
public static partial class ServiceMapper
{
    public static partial Service CreateServiceToService(this CreateServiceDto source);
    public static partial ServiceGotDto ServiceToServiceGot(this Service source);
}