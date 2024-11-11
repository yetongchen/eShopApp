﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Events
{
    public class OrderEvent
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string ShippingMethod { get; set; } = string.Empty;
        public decimal BillAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public List<OrderDetailEvent> OrderDetails { get; set; } = [];
    }
}
