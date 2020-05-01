using System;
using System.Collections.Generic;
namespace TinyCrm
{
    public class Order
    {
        public string OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> ListOfProduct;


        public Order()
        {
            //ListOfProduct.Add(new Product());
        }

        public Order(string orderid,string deliveryaddress,int[] x)//,int x,List<Product>lista)
        {
            ListOfProduct = new List<Product>();
            OrderId = orderid;
            DeliveryAddress = deliveryaddress;
           // Console.WriteLine(Program.listA[x].ProductId);
            //ListOfProduct.Add(Program.listA[x]);
            foreach(var i in x)
            {
                TotalAmount += Program.listA[i].Price;
            }
            Console.WriteLine(TotalAmount);
        }


    }
}
