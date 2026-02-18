namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
    public string RefreshToken { get; set; }
}
