using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EventHandlers
{
    public class ClientUpdateEventHandler : INotificationHandler<ClientUpdateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ClientUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientUpdateCommand notification, CancellationToken cancellationToken)
        {
            Client clientEdit = await _context.Clients.Where(x => x.ClientId == notification.ClientId).FirstAsync();

            clientEdit.Name = notification.Name;

            _context.Clients.Update(clientEdit);

            await _context.SaveChangesAsync();
        }
    }
}
