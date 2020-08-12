using System.Collections.Generic;
using System.Threading.Tasks;
using MMTTest.API.Models;

namespace MMTTest.API.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetFeatured();
        Task<List<Product>> GetByCategory(string category);
        Task<Product> GetBySku(string sku);
    }
}