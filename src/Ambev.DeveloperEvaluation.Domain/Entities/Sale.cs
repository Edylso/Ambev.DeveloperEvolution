using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system, including items, client, branch, and status.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the sale number (unique code for the sale).
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the client name (external identity).
    /// </summary>
    public string ClientName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the branch name where the sale was made (external identity).
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the total value of the sale.
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// Gets or sets whether the sale is canceled.
    /// </summary>
    public bool IsCanceled { get; set; }

    /// <summary>
    /// Gets or sets the list of items in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the sale.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
        SaleDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCanceled = true;
        UpdatedAt = DateTime.UtcNow;
    }
}
