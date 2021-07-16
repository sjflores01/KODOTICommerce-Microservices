using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enum;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHanlder : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ILogger<ProductInStockUpdateStockEventHanlder> _logger;
        private readonly ApplicationDbContext _context;

        public ProductInStockUpdateStockEventHanlder(ILogger<ProductInStockUpdateStockEventHanlder> logger,
            ApplicationDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrieve products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product {entry.ProductId} - doesn't have enough stock.");
                        throw new ProductInStockUpdateStockCommandException($"Product {entry.ProductId} - doesn't have enough stock.");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogError($"Product {entry.ProductId} - its stock was substracted by {item.Stock} - New stock {entry.Stock}.");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogError($"--- New stock record was created for {entry.ProductId} - because it didn't have any - New stock {entry.Stock}.");
                    }
                    entry.Stock += item.Stock;

                _logger.LogError($"Product {entry.ProductId} - its stock was increased by {item.Stock} - New stock {entry.Stock}.");
                }
            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");
        }
    }
}
