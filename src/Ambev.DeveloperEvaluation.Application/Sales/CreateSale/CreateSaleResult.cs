namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Result object for CreateSaleCommand
/// </summary>
public class CreateSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}