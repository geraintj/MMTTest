using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using MMTTest.API.Data;
using MMTTest.API.Models;
using Moq;
using Xunit;

namespace MMTTest.Tests
{
    public class CategoryRepositoryTests
    {
        private MMTShopContext _context;
        private ILogger<CategoryRepository> _logger;

        public CategoryRepositoryTests()
        {
            DbContextOptionsBuilder<MMTShopContext> optionsBuilder = new DbContextOptionsBuilder<MMTShopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new MMTShopContext(optionsBuilder.Options);

            _context.Categories.AddRange(new List<Category>()
            {
                new Category() {Id = Guid.NewGuid(), Name = "CategoryOne"},
                new Category() {Id = Guid.NewGuid(), Name = "CategoryTwo"},
                new Category() {Id = Guid.NewGuid(), Name = "CategoryThree"}
            });
            _context.SaveChanges();

            _logger = new NullLogger<CategoryRepository>();
        }

        [Fact]
        public async Task GetAllReturnsCorrectType()
        {
            // Arrange 
            var repo = new CategoryRepository(_context, _logger);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.IsType<List<Category>>(result);
        }

        [Fact]
        public async Task GetAllReturnsExpectedNumber()
        {
            // Arrange 
            var repo = new CategoryRepository(_context, _logger);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
