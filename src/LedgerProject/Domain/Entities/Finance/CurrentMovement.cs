using Core.Persistence.Entities;
using Domain.Entities.Corp;
using Domain.Enums;

namespace Domain.Entities.Finance;

public class CurrentMovement:Entity
{
    public int CurrentAccountId { get; set; }
    public virtual CurrentAccount? CurrentAccount { get; set; }
    public int AccountingPeriodId { get; set; }
    public virtual AccountingPeriod? AccountingPeriod { get; set; }
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public string Description { get; set; }
    public string? DocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public Direction Direction { get; set; }
    public decimal Amount { get; set; }
    public int MovementTypeId { get; set; }
    public virtual MovementType? MovementType { get; set; }
    public virtual List<CurrentMovementDetail> CurrentMovementDetails { get; set; }
}
