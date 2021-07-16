using Customer.Persistence.Database;
using Customer.Service.Queries;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Customer.Service.Queries
{
    public interface IClientQueryService
    {
        Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take);
        Task<ClientDTO> GetAsync(int id);
    }

    public class ClientQueryService:IClientQueryService
    {
        private readonly ApplicationDbContext _context;

        public ClientQueryService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<DataCollection<ClientDTO>> GetAllAsync(int page, int take)
        {
            var collection = await _context.Clients
                .OrderByDescending(x => x.ClientId)
                .GetPagedAsync(page, take);
            return collection.MapTo<DataCollection<ClientDTO>>();
        }

        public async Task<ClientDTO> GetAsync(int id)
        {
            return (await _context.Clients.SingleAsync(x => x.ClientId == id)).MapTo<ClientDTO>();
        }
    }
}
