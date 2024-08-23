namespace Application.User.DTOs.RequestDTOs
{
    public record SignUpConfirmationDto
    (
        string UserName,
        string Code
    );
}
