﻿using System;
namespace TinyCrm.Core.Model
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public OrderProduct()
        {
        }
    }
}