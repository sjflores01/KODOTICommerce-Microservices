﻿using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductCreateEventHanlder: INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateEventHanlder(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Handle(ProductCreateCommand command,CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            });
            await _context.SaveChangesAsync();
        }
    }
}
