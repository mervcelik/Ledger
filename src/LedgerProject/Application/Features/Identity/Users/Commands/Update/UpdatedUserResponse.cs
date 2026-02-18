namespace Application.Features.Identity.Users.Commands.Update;

public class UpdatedUserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; }
}
