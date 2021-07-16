using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class ClientCreateEventHandler : INotificationHandler<ClientCreateCommand>
    {
        private readonly ILogger<ClientCreateEventHandler> _logger;
        private readonly ApplicationDbContext _context;

        public ClientCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin create new Client Handle Method");
            
            await _context.AddAsync(new Client
            {
                Name = notification.Name
            });

            _logger.LogInformation($"Finished creating new Client: {notification.Name}");

            await _context.SaveChangesAsync();
        }
    }
}
