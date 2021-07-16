using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductUpdateEventHandler:INotificationHandler<ProductUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProductUpdateEventHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Handle(ProductUpdateCommand command, CancellationToken cancellationToken)
        {
            var productUpdate = await _context.Products.Where(x=>x.ProductId == command.ProductId).FirstAsync();
            productUpdate.Name = command.Name;
            productUpdate.Description = command.Description;
            productUpdate.Price = command.Price;
            _context.Products.Update(productUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
