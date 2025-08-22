using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validator for Sale entity, including business rules.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(s => s.ClientName)
            .NotEmpty().WithMessage("Client name is required.");

        RuleFor(s => s.BranchName)
            .NotEmpty().WithMessage("Branch name is required.");

        RuleFor(s => s.Items)
            .NotEmpty().WithMessage("At least one item is required.");

        RuleForEach(s => s.Items).SetValidator(new SaleItemValidator());
    }
}

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(i => i.ProductName)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(i => i.Quantity)
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");

        RuleFor(i => i.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
    }
}