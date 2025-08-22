using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity, following DDD repository pattern.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new sale in the data store.
    /// </summary>
    /// <param name="sale">The sale entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created sale entity.</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a sale by its unique identifier.
    /// </summary>
    /// <param name="id">The sale ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sale entity or null if not found.</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing sale in the data store.
    /// </summary>
    /// <param name="sale">The sale entity to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated sale entity.</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Cancels a sale by its unique identifier.
    /// </summary>
    /// <param name="id">The sale ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the sale was canceled, false otherwise.</returns>
    Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all sales.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of sales.</returns>
    Task<IReadOnlyList<Sale>> GetAllAsync(CancellationToken cancellationToken);
}