using Application.Common.Interfaces.Repositories;
using Application.User.DTOs.RequestDTOs;
using Application.User.DTOs.ResponseDTOs;
using Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserGotDto> Create(RegisterUserDto registerUserDto)
    {
        var userToCreate = registerUserDto.ToUser();

        var entity = (await _dbContext.Users.AddAsync(userToCreate)).Entity;
        await _dbContext.SaveChangesAsync();

        return entity.ToUserGot();
    }
    
    public async Task<UserGotDto> GetByIdAsync(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return user.ToUserGot();
    }
    
    public async Task<IEnumerable<UserGotDto>> GetAllAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        return users.Select(user => user.ToUserGot());
    }
    
    public async Task DeleteAsync(Guid userId)
    {
        var userToDelete = await _dbContext.Users.FindAsync(userId);

        if (userToDelete == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        _dbContext.Users.Remove(userToDelete);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserGotDto> UpdateAsync(int userId, UpdateUserDto updateUserDto)
    {
        var userToUpdate = await _dbContext.Users.FindAsync(userId);

        if (userToUpdate == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        userToUpdate.UpdateFromDto();

        _dbContext.Users.Update(userToUpdate);
        await _dbContext.SaveChangesAsync();

        return userToUpdate.ToUserGot();
    }
}