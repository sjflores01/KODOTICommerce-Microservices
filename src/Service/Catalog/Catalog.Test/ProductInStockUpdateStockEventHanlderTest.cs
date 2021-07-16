using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Test.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Catalog.Common.Enum;

namespace Catalog.Test
{
    [TestClass]
    public class ProductInStockUpdateStockEventHanlderTest
    {
        private ILogger<ProductInStockUpdateStockEventHanlder> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateStockEventHanlder>>()
                    .Object;

            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHanlder(GetLogger, context);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract
                    }
                }
            }, new CancellationToken()).Wait();
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHanlder(GetLogger, context);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDatabase = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(3, stockInDatabase);
        }

        [TestMethod]
        public void TryToAddStockWhenProductDoesntExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 4;
            var productId = 4;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 0
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHanlder(GetLogger, context);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add
                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDatabase = context.Stocks.Single(x => x.ProductId == productId).Stock;

            Assert.AreEqual(2, stockInDatabase);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateStockCommandException))]
        public void TryToSubstractStockWhenProductHasNoStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHanlder(GetLogger, context);
            try
            {
                handler.Handle(new ProductInStockUpdateStockCommand
                {
                    Items = new List<ProductInStockUpdateItem>() {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Substract
                    }
                }
                }, new CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {
                throw new ProductInStockUpdateStockCommandException(ae.Message);
            }
        }
    }
}
