using Microsoft.EntityFrameworkCore;
using MMTTest.API.Models;

namespace MMTTest.API.Data
{
    public class MMTShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFilter> CategoryFilters { get; set; }

        public MMTShopContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
