namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Request model for updating a sale
/// </summary>
public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public List<UpdateSaleItemRequest> Items { get; set; } = new();
}

public class UpdateSaleItemRequest
{
    public Guid? Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}