namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Result object for GetSaleQuery
/// </summary>
public class GetSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
    public bool IsCanceled { get; set; }
    public List<GetSaleItemResult> Items { get; set; } = new();
}

public class GetSaleItemResult
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalValue { get; set; }
    public bool IsCanceled { get; set; }
}