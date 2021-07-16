using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductsInStockController : Controller
    {
        private readonly ILogger<ProductsInStockController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;

        public ProductsInStockController(ILogger<ProductsInStockController> logger,
            IProductQueryService productQueryService,
            IMediator mediator)
        {
            this._logger = logger;
            this._productQueryService = productQueryService;
            this._mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
