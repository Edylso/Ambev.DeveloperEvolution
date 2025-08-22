using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API request model for CreateSale operation
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// The client name
    /// </summary>
    [Required]
    public string ClientName { get; set; } = string.Empty;

    /// <summary>
    /// The branch name
    /// </summary>
    [Required]
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// The list of items in the sale
    /// </summary>
    [Required]
    public List<CreateSaleItemRequest> Items { get; set; } = new();
}

public class CreateSaleItemRequest
{
    /// <summary>
    /// The product name
    /// </summary>
    [Required]
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    [Range(1, 20)]
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product
    /// </summary>
    [Range(0.01, double.MaxValue)]
    public decimal UnitPrice { get; set; }
}