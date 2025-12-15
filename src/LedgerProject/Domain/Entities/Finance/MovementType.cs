using Core.Persistence.Entities;
using Domain.Entities.Corp;

namespace Domain.Entities.Finance;

public class MovementType: Entity
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string Name { get; set; }
    public virtual List<CurrentMovement>? CurrentMovements { get; set; }
}