using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        public static List<Product> listA = new List<Product>();
        static void Main(string[] args)
        {
            try
            {
                Customer thbatzel = new Customer("123456789");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter your Vat again ");
            }




            var reader = new StreamReader("/Users/batzeliosthanos/Desktop/csv.txt");


            Random random = new Random();

            HashSet<string> id = new HashSet<string>();
            //List<Product> listA = new List<Product>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                //decimal price = random.Next(1000);
                var price = Math.Round(random.NextDouble() * 100, 2);
                var dec = (decimal)price;
                var dupl = listA.Any(o => o.ProductId.Equals(values[0]));

                if (!dupl)
                {
                    listA.Add(new Product(values[0], values[1], values[2], dec));

                }
            }

            listA.ForEach(item => Console.WriteLine(item.ProductId+ "  "+ item.Price));

            Customer cust1 = new Customer();
            Customer cust2 = new Customer();
            int[] ar1 = new int[3];
            int[] ar2 = new int[3];
            for (int i = 0; i < 3; i++)
            {
                //Console.WriteLine(listA.Count+"the lsist count ");
                ar1[i] = random.Next(listA.Count-1);
                //Console.WriteLine(ar1[i]);

                ar2[i]= random.Next(listA.Count - 1);
                //Console.WriteLine(ar2[i]);
            }
            cust1.ListOfOrders.Add(new Order("1", "aaa", ar1));
            cust2.ListOfOrders.Add(new Order("1", "aaa", ar2));

            if(cust1.ListOfOrders[0].TotalAmount> cust2.ListOfOrders[0].TotalAmount)
            {
                Console.WriteLine(" O cust1 is more valuable than cust2 ");
            }else if (cust1.ListOfOrders[0].TotalAmount < cust2.ListOfOrders[0].TotalAmount)
            {
                Console.WriteLine(" O cust2 is more valuable than cust1 ");
            }else
            {
                Console.WriteLine("is equal");
            }

            var ar3 = ar1.Concat(ar2);

            //foreach(var i in ar3)
            //{
            //    Console.WriteLine(i);
            //}

            var query = ar3.GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();

            Console.WriteLine(query);

        }
    }
}
