using System;
using System.Collections.Generic;
namespace TinyCrm
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }



        public Order()
        {
            Created = DateTimeOffset.Now;
            OrderProducts = new List<OrderProduct>();
            //ListOfProduct.Add(new Product());
        }

        public Order(int orderid,string deliveryaddress,int[] x)//,int x,List<Product>lista)
        {
            //ListOfProduct = new List<Product>();
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

        //public string GenerateID()
        //{
        //    OrderId = Guid.NewGuid().ToString("N");
        //    return OrderId;
        //}


    }
}
