using System;
namespace TinyCrm
{
    public class SearchProductOptions
    {
        public int? ProductId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public ProductCategory Category { get; set; }

        public SearchProductOptions()
        {
        }
    }
}
