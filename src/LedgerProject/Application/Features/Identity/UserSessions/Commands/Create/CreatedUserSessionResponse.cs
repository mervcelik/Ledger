namespace Application.Features.Identity.UserSessions.Commands.Create;

public class CreatedUserSessionResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
}
