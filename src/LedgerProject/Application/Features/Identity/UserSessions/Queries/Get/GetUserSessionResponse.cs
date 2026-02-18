namespace Application.Features.Identity.UserSessions.Queries.Get;

public class GetUserSessionResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? LogoutDate { get; set; }
}
