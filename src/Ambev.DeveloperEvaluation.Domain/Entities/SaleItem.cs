using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the product name (external identity).
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to this item (as a decimal, e.g., 0.10 for 10%).
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total value for this item (after discount).
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// Gets or sets whether the item is canceled.
    /// </summary>
    public bool IsCanceled { get; set; }

    /// <summary>
    /// Gets the date and time when the item was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the item.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Cancels the sale item.
    /// </summary>
    public void Cancel()
    {
        IsCanceled = true;
        UpdatedAt = DateTime.UtcNow;
    }
}