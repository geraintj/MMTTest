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
    public class ProductRepositoryTests
    {
        private MMTShopContext _context;
        private ILogger<ProductRepository> _logger;
        private Mock<IOptions<ApiOptions>> _configMock;

        public ProductRepositoryTests()
        {
            DbContextOptionsBuilder<MMTShopContext> optionsBuilder = new DbContextOptionsBuilder<MMTShopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new MMTShopContext(optionsBuilder.Options);

            _context.Products.AddRange(new List<Product>()
            {
                new Product() {Sku = "12345", Name = "Product1", Description = "Product1 is nice", Price = 9.99d },
                new Product() {Sku = "22345", Name = "Product2", Description = "Product2 is nice", Price = 9.99d },
                new Product() {Sku = "32345", Name = "Product3", Description = "Product3 is nice", Price = 9.99d },
                new Product() {Sku = "42345", Name = "Product4", Description = "Product4 is nice", Price = 9.99d },
                new Product() {Sku = "52345", Name = "Product5", Description = "Product5 is nice", Price = 9.99d },
            });
            _context.SaveChanges();

            _logger = new NullLogger<ProductRepository>();
            _configMock = new Mock<IOptions<ApiOptions>>();
        }

        [Fact]
        public async Task GetAllReturnsCorrectType()
        {
            // Arrange 
            var repo = new ProductRepository(_context, _logger, _configMock.Object);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public async Task GetAllReturnsExpectedNumber()
        {
            // Arrange 
            var repo = new ProductRepository(_context, _logger, _configMock.Object);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public async Task GetFeaturedReturnsCorrectType()
        {
            // Arrange 
            var config = Options.Create<ApiOptions>(new ApiOptions() { FeatureSkuPrefixes = new List<string>() { "3", "7" } });
            var repo = new ProductRepository(_context, _logger, config);

            // Act
            var result = await repo.GetFeatured();

            // Assert
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public async Task GetFeaturedReturnsExpectedNumber()
        {
            // Arrange 
            var config = Options.Create<ApiOptions>(new ApiOptions() { FeatureSkuPrefixes = new List<string>() { "3", "7" }});
            var repo = new ProductRepository(_context, _logger, config);

            // Act
            var result = await repo.GetFeatured();

            // Assert
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public async Task GetFeaturedCallsConfig()
        {
            // Arrange 
            _configMock.Setup(x => x.Value).Returns(new ApiOptions());
            var repo = new ProductRepository(_context, _logger, _configMock.Object);

            // Act
            var result = await repo.GetFeatured();

            // Assert
            _configMock.VerifyGet(x => x.Value, Times.Once);
        }


        [Fact]
        public async Task GetBySkuReturnsCorrectType()
        {
            // Arrange 
            var repo = new ProductRepository(_context, _logger, _configMock.Object);

            // Act
            var result = await repo.GetBySku("32345");

            // Assert
            Assert.IsType<Product>(result);
        }

        [Fact]
        public async Task GetBySkuReturnsCorrectProduct()
        {
            // Arrange 
            var repo = new ProductRepository(_context, _logger, _configMock.Object);

            // Act
            var result = await repo.GetBySku("32345");

            // Assert
            Assert.Equal("Product3", result.Name);
        }
    }
}
