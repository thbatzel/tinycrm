using System;
using System.Collections.Generic;
namespace TinyCrm
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        public Product(string productid,string name,string description,decimal price)
        {
            ProductId = productid;
            Name = name;
            Description = description;
            Price = price;


        }
    }
}
