using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static Order.Common.Enum;

namespace Order.Persistence.Database.Configuration
{
    public class OrderConfigration
    {
        public OrderConfigration(EntityTypeBuilder<Order.Domain.Order> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.OrderId);
        }
    }
}
