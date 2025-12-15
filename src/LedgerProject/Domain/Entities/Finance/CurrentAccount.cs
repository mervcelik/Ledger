using Core.Persistence.Entities;
using Domain.Entities.Corp;

namespace Domain.Entities.Finance;

public class CurrentAccount: Entity
{
    public string Name { get; set; }
    public string TaxNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public virtual List<CurrentMovement>? CurrentMovements { get; set; }
}
