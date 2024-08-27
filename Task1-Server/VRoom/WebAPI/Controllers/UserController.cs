using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.User.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class UserController : BaseApiController
{
    private IAuthService _authService;
    private readonly IUserRepository _userRepository;
    public UserController(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserInfo(Guid userId)
    {
        var response = await _userRepository.GetByIdAsync(userId);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _userRepository.GetAllAsync();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        var response = await _authService.RegisterAsync(registerUserDto);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthCredentialsDto authCredentialsDto)
    {
        var response = await _authService.LoginAsync(authCredentialsDto);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmRegistration(SignUpConfirmationDto dto)
    {
        var response = await _authService.ConfirmSignupAsync(dto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(int userId, UpdateUserDto updateUserDto)
    {
        var response = await _userRepository.UpdateAsync(userId, updateUserDto);
        return Ok(response);
    }
}