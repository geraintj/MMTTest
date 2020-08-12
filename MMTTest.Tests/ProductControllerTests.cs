using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using MMTTest.API.Controllers;
using MMTTest.API.Data;
using MMTTest.API.Models;
using Moq;
using Xunit;
using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;

namespace MMTTest.Tests
{
    public class ProductControllerTests
    {
        private NullLogger<ProductController> _logger;
        private Mock<IProductRepository> _repoMock;

        public ProductControllerTests()
        {
            _logger = new NullLogger<ProductController>();
            _repoMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task GetAllReturnsCorrectStatusIfNull()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetAllReturnsCorrectStatusIfNone()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Product>());
            var response = await controller.GetAll() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }


        [Fact]
        public async Task GetAllReturnsCorrectType()
        {
            // Arrange
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Product>() { new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<List<Product>>(response.Value);
        }

        [Fact]
        public async Task GetAllReturnsExpectedNumber()
        {
            // Arrange
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Product>() { new Product(), new Product(), new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            var result = response.Value as List<Product>;
            Assert.Equal(3, result?.Count);
        }

        [Fact]
        public async Task GetFeaturedReturnsCorrectStatusIfNull()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetFeatured() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetFeaturedReturnsCorrectStatusIfNone()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            _repoMock.Setup(x => x.GetFeatured()).ReturnsAsync(new List<Product>());
            var response = await controller.GetFeatured() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }


        [Fact]
        public async Task GetFeaturedReturnsCorrectType()
        {
            // Arrange
            _repoMock.Setup(x => x.GetFeatured()).ReturnsAsync(new List<Product>() { new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetFeatured() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<List<Product>>(response.Value);
        }

        [Fact]
        public async Task GetFeaturedReturnsExpectedNumber()
        {
            // Arrange
            _repoMock.Setup(x => x.GetFeatured()).ReturnsAsync(new List<Product>() { new Product(), new Product(), new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetFeatured() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            var result = response.Value as List<Product>;
            Assert.Equal(3, result?.Count);
        }

        [Fact]
        public async Task GetCategorisedReturnsCorrectStatusIfNull()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetByCategory("xxx") as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetCategorisedReturnsCorrectStatusIfNone()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            _repoMock.Setup(x => x.GetByCategory(It.IsAny<string>())).ReturnsAsync(new List<Product>());
            var response = await controller.GetByCategory("xxx") as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }


        [Fact]
        public async Task GetCategorisedReturnsCorrectType()
        {
            // Arrange
            _repoMock.Setup(x => x.GetByCategory(It.IsAny<string>())).ReturnsAsync(new List<Product>() { new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetByCategory("xxx") as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<List<Product>>(response.Value);
        }

        [Fact]
        public async Task GetCategorisedReturnsExpectedNumber()
        {
            // Arrange
            _repoMock.Setup(x => x.GetByCategory(It.IsAny<string>())).ReturnsAsync(new List<Product>() { new Product(), new Product(), new Product() });
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetByCategory("xxx") as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            var result = response.Value as List<Product>;
            Assert.Equal(3, result?.Count);
        }

        [Fact]
        public async Task GetOneReturnsCorrectStatusIfNull()
        {
            // Arrange
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetBySku("xxx") as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetOneReturnsCorrectly()
        {
            // Arrange
            _repoMock.Setup(x => x.GetBySku(It.IsAny<string>())).ReturnsAsync( new Product() {Name = "ProductName"});
            var controller = new ProductController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetBySku("xxx") as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<Product>(response.Value);
            var resultProduct = response.Value as Product;
            Assert.Equal("ProductName", resultProduct?.Name);
        }

    }
}
