using Application.Hotel.DTOs.RequestDTOs;
using Application.Hotel.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Persistence.Mappers;

[Mapper]
public static partial class HotelMapper
{
    public static partial Hotel CreateHotelToHotel(this CreateHotelDto source);
    public static partial HotelGotDto HotelToHotelGot(this Hotel source);
}