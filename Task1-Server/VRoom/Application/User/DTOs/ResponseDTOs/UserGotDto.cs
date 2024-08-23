using System;
using Application.Enums;

namespace Application.User.DTOs.ResponseDTOs;

public class UserGotDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Passport { get; set; }
}