using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using Customer.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientQueryService _clientQueryService;
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public ClientsController(ILogger<ClientsController> logger, ApplicationDbContext context,
            IClientQueryService clientQueryService, IMediator mediator)
        {
            _logger = logger;
            _context = context;
            _clientQueryService = clientQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDTO>> GetAll(int page = 1, int take =20)
        {
            return await _clientQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{clientId:int}")]
        public async Task<ClientDTO> GetById(int clientId)
        {
            return await _clientQueryService.GetAsync(clientId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand clientCreateCommand)
        {
            await _mediator.Publish(clientCreateCommand);
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ClientDTO>> Update(ClientUpdateCommand clientUpdateCommand)
        {
            await _mediator.Publish(clientUpdateCommand);
            
            ClientDTO updatedClient = await _clientQueryService.GetAsync(clientUpdateCommand.ClientId);
            
            return Ok(updatedClient);
        }
    }
}
