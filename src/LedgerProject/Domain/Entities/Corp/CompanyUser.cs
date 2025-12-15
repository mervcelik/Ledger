using Core.Persistence.Entities;
using Domain.Entities.Identity;

namespace Domain.Entities.Corp;

public class CompanyUser: Entity
{
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
}