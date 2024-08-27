using Application.Booking.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Persistence.Mappers;
[Mapper]
public static partial class BookingMapper
{
    public static partial BookingGotDto BookingToBookingDto(this Booking source);
}