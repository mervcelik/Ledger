using Core.Persistence.Entities;
using Domain.Entities.Corp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Identity;

public class User:Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public virtual List<UserOperationClaim>? UserOperationClaims { get; set; }
    public virtual List<UserSession>? UserSessions { get; set; }
    public virtual List<CompanyUser>? CompanyUsers { get; set; }
}
