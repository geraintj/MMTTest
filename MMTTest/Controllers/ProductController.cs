using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMTTest.API.Data;

namespace MMTTest.API.Controllers
{
    /// <summary>
    /// API controller returning Product entities
    /// </summary>
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo, ILogger<ProductController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Returns all stored entities of the type Product
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allProducts = await _repo.GetAll();

                if (allProducts == null || !allProducts.Any())
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(allProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Returns featured Product entities; 
        /// SKUs to "feature" defined in configuration
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet]
        [Route("featured")]
        public async Task<IActionResult> GetFeatured()
        {
            try 
            { 
                var featuredProducts = await _repo.GetFeatured();

                if (featuredProducts == null || !featuredProducts.Any())
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(featuredProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Returns Product entities in the specified Category
        /// </summary>
        /// <param name="category">Category name</param>
        /// <returns>Products</returns>
        [HttpGet]
        [Route("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            try
            { 
                var categoryProducts = await _repo.GetByCategory(category);

                if (categoryProducts == null || !categoryProducts.Any())
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(categoryProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Returns a single Product with the specified SKU
        /// </summary>
        /// <param name="sku">Identifier of Product</param>
        /// <returns>Product</returns>
        [HttpGet]
        [Route("{sku}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GetBySku(string sku)
        {
            try
            { 
                var product = await _repo.GetBySku(sku);

                if (product == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }

    }
}