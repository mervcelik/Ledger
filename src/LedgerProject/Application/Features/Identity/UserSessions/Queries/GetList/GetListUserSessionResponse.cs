namespace Application.Features.Identity.UserSessions.Queries.GetList;

public class GetListUserSessionResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string AccessToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? LogoutDate { get; set; }
}
