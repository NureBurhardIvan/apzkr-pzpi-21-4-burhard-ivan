
using System;

namespace Application.User.DTOs.RequestDTOs
{
    public record RegisterUserDto
    (
        Guid? Id,
        string UserName,
        string Password,
        string Email,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Passport
    );
}
