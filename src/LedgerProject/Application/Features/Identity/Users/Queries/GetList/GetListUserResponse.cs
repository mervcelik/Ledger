namespace Application.Features.Identity.Users.Queries.GetList;

public class GetListUserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public bool Status { get; set; }
}
