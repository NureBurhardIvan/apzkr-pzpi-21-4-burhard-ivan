using Application.Room.DTOs.RequestDTOs;
using Application.Room.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Persistence.Mappers;

[Mapper]
public static partial class RoomMapper
{
    public static partial Room CreateRoomToRoom(this CreateRoomDto source);
    public static partial RoomGotDto RoomToRoomGot(this Room source);
}