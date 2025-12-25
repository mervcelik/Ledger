using Core.Application.Dtos;

namespace Application.Features.Finance.AccountingPeriods.Queries.Get;

public class GetAccountingPeriodResponse : BaseResponseDto
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
    public int CompanyId { get; set; }
}
