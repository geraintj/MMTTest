using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MMTTest.API.Controllers;
using MMTTest.API.Data;
using MMTTest.API.Models;
using Moq;
using Xunit;
using OkObjectResult = Microsoft.AspNetCore.Mvc.OkObjectResult;

namespace MMTTest.Tests
{
    public class CategoryControllerTests
    {
        private ILogger<CategoryController> _logger;
        private Mock<ICategoryRepository> _repoMock;
        
        public CategoryControllerTests()
        {
            _logger = new NullLogger<CategoryController>();
            _repoMock = new Mock<ICategoryRepository>();
        }

        [Fact]
        public async Task GetAllReturnsCorrectStatusIfNull()
        {
            // Arrange
            var controller = new CategoryController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetAllReturnsCorrectStatusIfNone()
        {
            // Arrange
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Category>());
            var controller = new CategoryController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as NotFoundResult;

            // Assert
            Assert.NotNull(response);
        }


        [Fact]
        public async Task GetAllReturnsCorrectType()
        {
            // Arrange
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Category>() { new Category() { Name = "CategoryName1"} });
            var controller = new CategoryController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.IsType<List<string>>(response.Value);
        }

        [Fact]
        public async Task GetAllReturnsExpectedNumber()
        {
            // Arrange
            _repoMock.Setup(x => x.GetAll()).ReturnsAsync(new List<Category>()
            {
                new Category() { Name = "CategoryName1" },
                new Category() { Name = "CategoryName2" },
                new Category() { Name = "CategoryName3" }
            });
            var controller = new CategoryController(_repoMock.Object, _logger);

            // Act
            var response = await controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(response);
            var result = response.Value as List<string>;
            Assert.Equal(3, result?.Count);
        }

    }
}
