namespace Application.Features.Finance.CurrentAccounts.Queries.GetList;

public class GetListCurrentAccountResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TaxNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public DateTime CreatedDate { get; set; }
}