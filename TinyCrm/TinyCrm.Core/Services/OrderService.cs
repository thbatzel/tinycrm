using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customerService_;
        private IProductService productService_;

        public OrderService(TinyCrmDbContext context,ICustomerService customerService )
        {
            context_ = context;
            customerService_ = customerService;
        }

        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = customerService_.SearchCustomers(new SearchCustomerOptions
            {
                CustomerId = options.CustomerId
            }).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }


            var order = new Order();

            foreach(var prod in options.ProductsId)
            {
                if(prod == null)
                {
                    continue;
                }

                var product = productService_.SearchProduct(new SearchProductOptions()
                {
                    ProductId = prod
                }).SingleOrDefault();

                if(product != null)
                {
                    var orderprod = new OrderProduct()
                    {
                        Product = product
                    };

                    order.OrderProducts.Add(orderprod);

                }
            }

            if(order.OrderProducts.Count == 0)
            {
                return null;
            }

            customer.Orders.Add(order);
            context_.Update(customer);
            context_.Add(order);

            if (context_.SaveChanges() > 0)
            {
                return order;
            }
            return null;
        }

        public Order GetOrderById(int orderid)
        {

            var order = SearchOrder(new SearchOrderOptions
            {
                OrderId = orderid
            }).SingleOrDefault();

            return order;
        }

        public List<Order> SearchOrder(SearchOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var oResults = context_.Set<Customer>()
                .Where(o => o.CustomerId == options.CustomerId)
                .Include(c => c.Orders).SingleOrDefault();

            return oResults.Orders;
        }


        public Order UpdateOrder(UpdateOrderOptions options)
        {
            throw new NotImplementedException();
        }

    }
}
