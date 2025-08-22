using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale
/// </summary>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string ClientName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public List<CreateSaleItemCommand> Items { get; set; } = new();
}

public class CreateSaleItemCommand
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}