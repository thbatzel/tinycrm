using System;
using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CreateCustomerOptions options);
        IQueryable<Customer> SearchCustomers(SearchCustomerOptions options);
        Customer UpdateCustomer(UpdateCustomerOptions options,int id);
        Customer GetCustomerById(int id);



    }
}
