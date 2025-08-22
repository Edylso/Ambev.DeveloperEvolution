using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command to update a sale
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public List<UpdateSaleItemCommand> Items { get; set; } = new();
}

public class UpdateSaleItemCommand
{
    public Guid? Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}