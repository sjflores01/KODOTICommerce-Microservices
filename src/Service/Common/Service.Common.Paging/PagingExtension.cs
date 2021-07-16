using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Service.Common.Collection;
using Microsoft.EntityFrameworkCore;

namespace Service.Common.Paging
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take
            )
        {
            var originalPage = page;
            page--;
            if(page > 0)
            {
                page = page * take;
            }

            var result = new DataCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPage
            };

            if(result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
