namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Result object for UpdateSaleCommand
/// </summary>
public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
    public bool IsCanceled { get; set; }
}