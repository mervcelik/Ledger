using Core.Persistence.Repositories;

namespace Domain.Entities.Identity;

public class  OperationClaim:Entity
{
    public string Name { get; set; }

    public virtual List<UserOperationClaim>? UserOperationClaims { get; set; }
}
