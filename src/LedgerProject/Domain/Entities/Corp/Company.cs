using Core.Persistence.Repositories;
using Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Corp;

public class Company : Entity
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? TaxNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual List<CompanyUser>? CompanyUsers { get; set; }
    public virtual List<AccountingPeriod>? AccountingPeriods { get; set; }
    public virtual List<CurrentAccount>? CurrentAccount { get; set; }
    public virtual List<CurrentMovement>? CurrentMovements { get; set; }
}
