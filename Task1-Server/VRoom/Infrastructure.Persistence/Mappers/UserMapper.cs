using Application.User.DTOs.RequestDTOs;
using Application.User.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Persistence.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static User ToUser(this RegisterUserDto source)
    {
        return new User()
        {
            Email = source.Email,
            FirstName = source.FirstName,
            Id = source.Id.GetValueOrDefault(),
            LastName = source.LastName,
            Phone = source.PhoneNumber,
            Passport = source.Passport,
            Role = Role.User,
            Username = source.UserName
        };
    }

    public static UserGotDto ToUserGot(this User source)
    {
        return new UserGotDto()
        {
            Email = source.Email,
            FirstName = source.FirstName,
            Id = source.Id,
            LastName = source.LastName,
            Phone = source.Phone,
            Passport = source.Passport,
            Role = source.Role.InfRoleToAppRole(),
            Username = source.Username
        };
    }

    private static Application.Enums.Role InfRoleToAppRole(this Role source)
    {
        switch (source)
        {
            case Role.User:
                return Application.Enums.Role.User;
            case Role.Admin:
                return Application.Enums.Role.Admin;
            case Role.Staff:
                return Application.Enums.Role.Staff;
            case Role.SuperAdmin:
                return Application.Enums.Role.SuperAdmin;
            case Role.Guest:
                return Application.Enums.Role.Guest;
            default: return Application.Enums.Role.User;
        }
    }
    public static partial User UpdateFromDto(this User source);
}