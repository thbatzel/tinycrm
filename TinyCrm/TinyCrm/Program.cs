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
            //try
            //{
            //    Customer thbatzel = new Customer("123456789");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Please enter your Vat again ");
            //}


            //var reader = new StreamReader("/Users/batzeliosthanos/Desktop/csv.txt");


            //Random random = new Random();

            //HashSet<string> id = new HashSet<string>();
            ////List<Product> listA = new List<Product>();
            //while (!reader.EndOfStream)
            //{
            //    var line = reader.ReadLine();
            //    var values = line.Split(';');
            //    //decimal price = random.Next(1000);
            //    var price = Math.Round(random.NextDouble() * 100, 2);
            //    var dec = (decimal)price;
            //    var dupl = listA.Any(o => o.ProductId.Equals(values[0]));

            //    if (!dupl)
            //    {
            //        listA.Add(new Product(values[0], values[1], values[2], dec));

            //    }
            //}

            //listA.ForEach(item => Console.WriteLine(item.ProductId+ "  "+ item.Price));

            //Customer cust1 = new Customer();
            //Customer cust2 = new Customer();
            //int[] ar1 = new int[3];
            //int[] ar2 = new int[3];
            //for (int i = 0; i < 3; i++)
            //{
            //    //Console.WriteLine(listA.Count+"the lsist count ");
            //    ar1[i] = random.Next(listA.Count-1);
            //    //Console.WriteLine(ar1[i]);

            //    ar2[i]= random.Next(listA.Count - 1);
            //    //Console.WriteLine(ar2[i]);
            //}
            //cust1.ListOfOrders.Add(new Order("1", "aaa", ar1));
            //cust2.ListOfOrders.Add(new Order("1", "aaa", ar2));

            //if(cust1.ListOfOrders[0].TotalAmount> cust2.ListOfOrders[0].TotalAmount)
            //{
            //    Console.WriteLine(" O cust1 is more valuable than cust2 ");
            //}else if (cust1.ListOfOrders[0].TotalAmount < cust2.ListOfOrders[0].TotalAmount)
            //{
            //    Console.WriteLine(" O cust2 is more valuable than cust1 ");
            //}else
            //{
            //    Console.WriteLine("is equal");
            //}

            //var ar3 = ar1.Concat(ar2);

            //foreach(var i in ar3)
            //{
            //    Console.WriteLine(i);
            //}

            //var query = ar3.GroupBy(item => item).OrderByDescending(g => g.Count()).Select(g => g.Key).First();

            //Console.WriteLine(query);


            //insert
            var tinycrmdbcontext = new TinyCrmDbContext();
            var customer = new Customer()
            {
                Firstname = "Xaris",
                Lastname = "Mpouras",
                Email = "mpouras.gr"
            };

            tinycrmdbcontext.Add(customer);
            tinycrmdbcontext.SaveChanges();

            var petrogiannos = new Customer()
            {
                Firstname = "Dimitris",
                Lastname = "Petrogiannos",
                Email = "petrogiannos.gr"
            };

            tinycrmdbcontext.Add(petrogiannos);
            tinycrmdbcontext.SaveChanges();

            var thbatzel = new Customer()
            {
                Firstname = "Thanos",
                Lastname = "Batzelios",
                Email = "th.batzel@gmail.com"
            };

            tinycrmdbcontext.Add(thbatzel);
            tinycrmdbcontext.SaveChanges();



            var customer2 = tinycrmdbcontext
            .Set<Customer>()
            .Where(c => c.CustomerId == customer.CustomerId)
            .SingleOrDefault();

            customer2.VatNumber = "123456789";
            tinycrmdbcontext.SaveChanges();


            var product = new Product()
            {
                Category = ProductCategory.Mobiles,
                Name = "IPhone 100",
                Price = 1500M
            };

            tinycrmdbcontext.Add(product);
            tinycrmdbcontext.SaveChanges();

            var product2 = new Product()
            {
                Category = ProductCategory.Mobiles,
                Name = "Sumsung",
                Price = 1500M
            };

            var order = new Order()
            {
                DeliveryAddress = "Athina TK 15343"
            };

            order.OrderProducts.Add(
                new OrderProduct()
                {
                    Product = product2
                });

            var customerWithOrders = new Customer()
            {
                Firstname = "Dimitris",
                Lastname = "Tzempentzis",
                Email = "dtzempentzis@mail.com"
            };

            customerWithOrders.Orders.Add(order);

            tinycrmdbcontext.Add(customerWithOrders);
            tinycrmdbcontext.SaveChanges();


            var results = SearchCustomers(
                new SearchCustomerOptions()
            {
                VatNumber = "117003949"
            }, tinycrmdbcontext)
            .Where(c => c.TotalGross > 500M)
            .Any();

        }

        public static IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options, TinyCrmDbContext dbContext)
        {
            if (options == null)
            {
                return null;
            }

            var query = dbContext
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Firstname))
            {
                query = query.Where(c => c.Firstname == options.Firstname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }


        public static IQueryable<Product> SearchProduct(SearchProductOptions options)
        {
            if (options == null)
            {
                //throw new ArgumentNullException("NULL Option");
                return null;
            }

            using (var dbcontex = new TinyCrmDbContext()) // θα εχεις προβλημα με το using 
            {
                var query = dbcontex.Set<Product>().AsQueryable();
                //if (!string.IsNullOrWhiteSpace(options.Categories))
                //{
                //    query = query.Where(p => p.ProductCategory == options.Categories);
                //}

                if (options.ProductId != null)
                {
                    query = query.Where(p => p.ProductId == options.ProductId.Value);
                }

                if (options.PriceFrom != null)
                {
                    query = query.Where(c => c.Price >= options.PriceFrom);
                }

                if (options.PriceTo != null)
                {
                    query = query.Where(c => c.Price >= options.PriceTo);
                }


                query = query.Take(500);
                return query;
            }

        }



    }
}
