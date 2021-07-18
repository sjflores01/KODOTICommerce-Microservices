using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Service.Queries
{
    public class OrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<OrderDto>> GetAllAsync(int page, int take)
        {
            var collection = await _context.Orders
                .Include(x => x.Items)
                .OrderByDescending(x => x.OrderId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDto>>();
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            return (await _context.Orders.Include(x => x.Items).SingleAsync(x => x.OrderId == id)).MapTo<OrderDto>();
        }
    }
}
