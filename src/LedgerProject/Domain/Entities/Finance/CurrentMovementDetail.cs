using Core.Persistence.Entities;

namespace Domain.Entities.Finance;

public class CurrentMovementDetail : Entity
{
    public int CurrentMovementId { get; set; }
    public virtual CurrentMovement? CurrentMovement { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Amount { get; set; }
    public int TaxPercient { get; set; }
    public decimal TotalAmount { get; set; }
}