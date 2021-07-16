using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.EventHandlers.Commands
{
    public class ProductUpdateCommand: INotification
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
