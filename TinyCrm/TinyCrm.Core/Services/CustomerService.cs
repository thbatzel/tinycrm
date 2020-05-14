using System;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;

        
        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }


        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var customer = new Customer()
            {
                Lastname = options.Lastname,
                Firstname = options.Firstname,
                VatNumber = options.VatNumber
            };
            context_.Add(customer);
            if(context_.SaveChanges() > 0)
            {
                return customer;
            }
            return null;

        }

        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
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

        public Customer UpdateCustomer(UpdateCustomerOptions options,int customerid)
        {
            if (options == null)
            {
                return null;
            }

            var customer = SearchCustomers(new SearchCustomerOptions
            {
                CustomerId = customerid
            }).SingleOrDefault();
            if (customer != null)
            {
                customer.Firstname = options.Firstname;
                customer.IsActive = options.IsActive;
                customer.Email = options.Email;

            }

            //context_.Add(customer);
            //context_.SaveChanges();
            if (context_.SaveChanges() >= 0)
            {
                return customer;
            }


            return null;
        }

        public Customer GetCustomerById(int customerid)
        {

            var customer = SearchCustomers(new SearchCustomerOptions
            {
               CustomerId = customerid
            }).SingleOrDefault();

            return customer;

        }

    }
}
