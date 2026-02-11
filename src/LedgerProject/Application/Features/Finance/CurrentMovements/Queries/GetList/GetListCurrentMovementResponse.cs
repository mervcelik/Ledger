using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Finance.CurrentMovements.Queries.GetList;

public class GetListCurrentMovementResponse
{
    public int Id { get; set; }
    public int CurrentAccountId { get; set; }
    public int AccountingPeriodId { get; set; }
    public int CompanyId { get; set; }
    public string Description { get; set; }
    public string? DocumentNumber { get; set; }
    public DateTime Date { get; set; }
    public Direction Direction { get; set; }
    public decimal Amount { get; set; }
    public int MovementTypeId { get; set; }
    public string MovementTypeName { get; set; }
}
