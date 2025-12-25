using Core.Application.Dtos;

namespace Application.Features.Finance.AccountingPeriods.Commands.Create;

public class CreatedAccountingPeriodResponse:BaseResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
    public int CompanyId { get; set; }
}
