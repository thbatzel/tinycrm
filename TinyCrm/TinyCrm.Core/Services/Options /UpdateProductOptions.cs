using System;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class UpdateProductOptions
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }

        public UpdateProductOptions()
        {
        }
    }
}
