using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for UpdateSaleCommand
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateSaleHandler> _logger;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<UpdateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException("Sale not found.");

        sale.ClientName = command.ClientName;
        sale.BranchName = command.BranchName;
        sale.UpdatedAt = DateTime.UtcNow;

        // Atualiza itens
        sale.Items.Clear();
        decimal total = 0;
        foreach (var itemCmd in command.Items)
        {
            if (itemCmd.Quantity > 20)
                throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");

            decimal discount = 0;
            if (itemCmd.Quantity >= 10 && itemCmd.Quantity <= 20)
                discount = 0.20m;
            else if (itemCmd.Quantity >= 4)
                discount = 0.10m;

            var item = new SaleItem
            {
                Id = itemCmd.Id ?? Guid.NewGuid(),
                ProductName = itemCmd.ProductName,
                Quantity = itemCmd.Quantity,
                UnitPrice = itemCmd.UnitPrice,
                Discount = discount,
                TotalValue = itemCmd.UnitPrice * itemCmd.Quantity * (1 - discount),
                CreatedAt = DateTime.UtcNow,
                IsCanceled = false
            };

            sale.Items.Add(item);
            total += item.TotalValue;
        }
        sale.TotalValue = total;

        var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);

        _logger.LogInformation(
            "Evento: VendaModificada | VendaId: {SaleId} | Numero: {SaleNumber} | Cliente: {ClientName} | ValorTotal: {TotalValue}",
            updatedSale.Id, updatedSale.SaleNumber, updatedSale.ClientName, updatedSale.TotalValue
        );

        return _mapper.Map<UpdateSaleResult>(updatedSale);
    }
}