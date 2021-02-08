using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ContactNumber { get; set; }
        public Address Address { get; set; }
        public List<Item> Items { get; set; }
        public decimal Cost { get; set; }
        public DateTime Starting { get; set; }
        public DateTime? Confirming { get; set; }
        public OrderStatus Status { get; set; }
    }
}