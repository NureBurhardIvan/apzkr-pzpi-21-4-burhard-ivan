   
using System.Threading.Tasks;
using Application.User.DTOs.RequestDTOs;
using Application.User.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<UserGotDto> Create(RegisterUserDto registerUserDto);
}