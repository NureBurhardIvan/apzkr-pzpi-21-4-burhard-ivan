   
using System.Threading.Tasks;
using Application.User.DTOs.RequestDTOs;
using Application.User.DTOs.ResponseDTOs;

namespace Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    public Task<UserGotDto> Create(RegisterUserDto registerUserDto);
    public Task<UserGotDto> GetByIdAsync(Guid userId);
    public Task<IEnumerable<UserGotDto>> GetAllAsync();
    public Task<UserGotDto> UpdateAsync(int userId, UpdateUserDto updateUserDto);
}