using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger,
            IProductQueryService productQueryService,
            IMediator mediator)
        {
            this._logger = logger;
            this._productQueryService = productQueryService;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("{productId:int}")]
        public async Task<ProductDto> Get(int productId)
        {
            return await _productQueryService.GetAsync(productId);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

    }
}
