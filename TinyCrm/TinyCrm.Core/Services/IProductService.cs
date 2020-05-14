using System;
using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IProductService
    {
        Product CreateProduct(CreateProductOptions options);
        IQueryable<Product> SearchProduct(SearchProductOptions options);
        Product UpdateProduct(UpdateProductOptions options);
        Product GetProductById(int id);
    }
}
