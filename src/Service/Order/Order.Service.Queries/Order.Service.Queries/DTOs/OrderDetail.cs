using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Service.Queries
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }
    }
}
