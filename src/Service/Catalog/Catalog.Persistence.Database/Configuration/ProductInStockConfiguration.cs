using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductInStockId);
            entityBuilder.Property(x => x.ProductInStockId).IsRequired();
            entityBuilder.Property(x => x.ProductId).IsRequired();
            entityBuilder.Property(x => x.Stock).IsRequired();

            var productsInStock = new List<ProductInStock>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                productsInStock.Add(new ProductInStock
                {
                    ProductInStockId = i,
                    ProductId = i,
                    Stock = random.Next(0,20)
                });
            }

            entityBuilder.HasData(productsInStock);
        }
    }
}
