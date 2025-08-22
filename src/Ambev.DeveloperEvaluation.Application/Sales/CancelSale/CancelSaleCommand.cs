using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Command to cancel a sale by its ID
/// </summary>
public class CancelSaleCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public CancelSaleCommand() { }

    public CancelSaleCommand(Guid id)
    {
        Id = id;
    }
}