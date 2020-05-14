using System;
using System.Collections.Generic;

namespace TinyCrm.Core.Services.Options
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public List<int> ProductsId { get; set; }

        public CreateOrderOptions()
        {
            ProductsId = new List<int> ();
        }
    }
}
