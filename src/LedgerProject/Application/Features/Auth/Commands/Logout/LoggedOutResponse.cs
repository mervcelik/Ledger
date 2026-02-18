namespace Application.Features.Auth.Commands.Logout;

public class LoggedOutResponse
{
    public int UserId { get; set; }
    public DateTime LogoutDate { get; set; }
}
