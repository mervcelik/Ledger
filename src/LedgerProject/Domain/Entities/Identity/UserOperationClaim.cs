using Core.Persistence.Entities;

namespace Domain.Entities.Identity;

public class UserOperationClaim:Entity
{
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int OperationClaimId { get; set; }
    public virtual OperationClaim? OperationClaim { get; set; }
}