namespace Application.Features.Finance.CurrentMovementDetails.Queries.GetList;

public class GetListCurrentMovementDetailResponse
{
    public int Id { get; set; }
    public int CurrentMovementId { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public decimal Amount { get; set; }
    public int TaxPercient { get; set; }
    public decimal TotalAmount { get; set; }
}