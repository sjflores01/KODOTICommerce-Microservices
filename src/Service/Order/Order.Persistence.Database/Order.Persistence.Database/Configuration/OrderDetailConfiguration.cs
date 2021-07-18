using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Persistence.Database.Configuration
{
    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<OrderDetail> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.OrderDetailId);
        }
    }
}
