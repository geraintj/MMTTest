using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MMTTest.API.Models;

namespace MMTTest.API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MMTShopContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(MMTShopContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Category>> GetAll()
        {
            try
            { 
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
