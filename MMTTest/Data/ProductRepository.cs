using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MMTTest.API.Models;

namespace MMTTest.API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MMTShopContext _context;
        private readonly ILogger<ProductRepository> _logger;
        private readonly IOptions<ApiOptions> _config;

        public ProductRepository(MMTShopContext context, ILogger<ProductRepository> logger, IOptions<ApiOptions> config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }
        
        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<List<Product>> GetFeatured()
        {
            try
            {
                var featurePrefixes = _config.Value.FeatureSkuPrefixes;
                return await _context.Products.Where(x => featurePrefixes.Contains(x.Sku.Substring(0,1))).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            try 
            { 
                return await _context.Products
                    .FromSqlRaw($"EXECUTE dbo.GetProductsByCategory '{category}'")
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<Product> GetBySku(string sku)
        {
            try 
            { 
                return await _context.Products.FindAsync(sku);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
