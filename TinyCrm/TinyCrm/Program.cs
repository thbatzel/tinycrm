using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                var customerService = new CustomerService(context);

                //var results = customerService.SearchCustomers(
                //    new SearchCustomerOptions()
                //    {
                //        CustomerId = 3
                //    }).SingleOrDefault();

                //Console.WriteLine(results.Firstname);

                var result = customerService.CreateCustomer(new CreateCustomerOptions
                {
                    Firstname = "Thanos",
                    Lastname = "batzelios",
                    VatNumber= "123456789"
                    
                    
                });

                Console.WriteLine(result.Firstname);

                //var up = customerService.UpdateCustomer(new UpdateCustomerOptions
                //{
               
                //    Email = "batzelios@gmail.com"
                //},2);
            }

        }
    }
}
