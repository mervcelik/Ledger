namespace Application.Features.Identity.UserSessions.Commands.Update;

public class UpdatedUserSessionResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime? LogoutDate { get; set; }
}
