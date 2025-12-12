using Core.Persistence.Repositories;
using Domain.Entities.Corp;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Finance;

public class AccountingPeriod : Entity
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public virtual List<CurrentMovement>? CurrentMovements { get; set; }
}

public class CurrentAccount
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

public class CurrentMovement
{
    public int CurrentAccountId { get; set; }
    public virtual CurrentAccount? CurrentAccount { get; set; }
    public int AccountingPeriodId { get; set; }
    public virtual AccountingPeriod? AccountingPeriod { get; set; }
    public int CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public string Description { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public Direction Direction { get; set; }
    public decimal Amount { get; set; }
    public int MovementTypeId { get; set; }
    public virtual MovementType? MovementType { get; set; }
}
public class MovementType
{
    public string Name { get; set; }
    public virtual List<CurrentMovement>? CurrentMovements { get; set; }
}