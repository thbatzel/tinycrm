using System;
namespace TinyCrm.Core.Services.Options
{
    public class SearchOrderOptions
    {

        public string DeliveryAddress { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }




        public SearchOrderOptions()
        {
        }
    }
}
