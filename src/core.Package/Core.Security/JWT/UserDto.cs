using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security.JWT;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
}
