﻿namespace BikeMania.Data.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
