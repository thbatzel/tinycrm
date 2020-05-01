using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
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




            var reader = new StreamReader("/Users/batzeliosthanos/Desktop/test.txt");


            Random random = new Random();

            HashSet<string> id = new HashSet<string>();
            List<Product> listA = new List<Product>();
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

        }
    }
}
