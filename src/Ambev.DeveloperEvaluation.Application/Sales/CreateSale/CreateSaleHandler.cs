using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<CreateSaleHandler> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Regra de negócio: Não permitir vendas duplicadas com mesmo número (exemplo, pode ser ajustado)
        // var existingSale = await _saleRepository.GetBySaleNumberAsync(command.SaleNumber, cancellationToken);
        // if (existingSale != null)
        //     throw new InvalidOperationException($"Sale with number {command.SaleNumber} already exists");

        var sale = _mapper.Map<Sale>(command);

        // Geração de SaleNumber e datas
        sale.SaleNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        sale.SaleDate = DateTime.UtcNow;
        sale.CreatedAt = DateTime.UtcNow;
        sale.IsCanceled = false;

        // Calcula descontos e totais dos itens
        decimal total = 0;
        foreach (var item in sale.Items)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException("Its not possible to create more than 20 equals itens in sale.");

            decimal discount = 0;
            if (item.Quantity >= 10 && item.Quantity <= 20)
                discount = 0.20m;
            else if (item.Quantity >= 4)
                discount = 0.10m;

            item.Discount = discount;
            item.TotalValue = item.UnitPrice * item.Quantity * (1 - discount);
            item.CreatedAt = DateTime.UtcNow;
            item.IsCanceled = false;

            total += item.TotalValue;
        }
        sale.TotalValue = total;

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        // Event log created sale
        _logger.LogInformation(
            "Evento: VendaCriada | VendaId: {SaleId} | Numero: {SaleNumber} | Cliente: {ClientName} | ValorTotal: {TotalValue}",
            createdSale.Id, createdSale.SaleNumber, createdSale.ClientName, createdSale.TotalValue
        );

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}