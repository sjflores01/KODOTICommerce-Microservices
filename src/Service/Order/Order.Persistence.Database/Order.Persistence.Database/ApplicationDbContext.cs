using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Persistence.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Order.Domain.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Order");
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder builder)
        {
            new OrderConfigration(builder.Entity<Domain.Order>());
            new OrderDetailConfiguration(builder.Entity<OrderDetail>());
        }
    }
}
