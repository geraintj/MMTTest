using System.Collections.Generic;
using System.Threading.Tasks;
using MMTTest.API.Models;

namespace MMTTest.Console
{
    public interface IApiCaller
    {
        Task<List<Product>> FeaturedProducts();
        Task<List<string>> AvailableCategories();
        Task<List<Product>> ProductsByCategory(string category);
    }
}