using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale Id is required.");
        RuleFor(x => x.ClientName).NotEmpty().WithMessage("Client name is required.");
        RuleFor(x => x.BranchName).NotEmpty().WithMessage("Branch name is required.");
        RuleFor(x => x.Items).NotEmpty().WithMessage("At least one item is required.");
        RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemValidator());
    }
}

public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
{
    public UpdateSaleItemValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.Quantity).InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
    }
}