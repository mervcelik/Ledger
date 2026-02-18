namespace Application.Features.Identity.Users.Queries.Get;

public class GetUserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public bool Status { get; set; }
}
