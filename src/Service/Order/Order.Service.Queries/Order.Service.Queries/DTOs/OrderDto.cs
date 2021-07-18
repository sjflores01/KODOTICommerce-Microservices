using System;
using System.Collections.Generic;
using System.Text;
using static Order.Common.Enum;

namespace Order.Service.Queries
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public OrderPayment PaymentType { get; set; }

        public int ClientId { get; set; }

        public ICollection<OrderDetail> Items { get; set; } = new List<OrderDetail>();

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }
    }
}
