using System;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context_;

        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var product = new Product()
            {
                Name = options.Name
            };
           // context_.Add(product);
            if (context_.SaveChanges() > 0)
            {
                return product;
            }
            return null;

        }

        public Product GetProductById(int productid)
        {


           var product = SearchProduct(new SearchProductOptions
           {
               ProductId = productid
           }).SingleOrDefault();

            return product;

        }

        public IQueryable<Product> SearchProduct(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Product>()
                .AsQueryable();

            if (options.Category != null)
            {
                query = query.Where(p => p.Category == options.Category);
            }

            if (options.ProductId != null)
            {
                query = query.Where(p => p.ProductId == options.ProductId.Value);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(p => p.Price > options.PriceTo && p.Price < options.PriceTo);
            }

            query = query.Take(500);

            return query;
        }

        public Product UpdateProduct(UpdateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

           var product = SearchProduct(new SearchProductOptions
           {
               ProductId = options.ProductId
           }).SingleOrDefault();

            if (product != null)
            {
                product.Name = options.Name;
                product.Description = options.Description;

            }

            context_.Add(product);
            if (context_.SaveChanges() > 0)
            {
                return product;
            }

            return null;
        }
    }
}
