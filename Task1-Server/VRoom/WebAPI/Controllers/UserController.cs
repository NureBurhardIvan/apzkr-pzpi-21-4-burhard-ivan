using Application.Common.Interfaces.Services;
using Application.User.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[AllowAnonymous]
public class UserController : BaseApiController
{
    private IAuthService _authService;
    public UserController(IAuthService authService)
    {
        _authService = authService;
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
}