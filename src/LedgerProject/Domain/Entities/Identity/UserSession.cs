using Core.Persistence.Repositories;

namespace Domain.Entities.Identity;

public class UserSession:Entity
{
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? LogoutDate { get; set; }
    public string? Description { get; set; }
}