using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMTTest.API.Data;

namespace MMTTest.API.Controllers
{
    /// <summary>
    /// API controller returning Category entities
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repo, ILogger<CategoryController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        /// <summary>
        /// Returns all stored entities of the type Category
        /// </summary>
        /// <returns>Categories</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            { 
                var allCategories = await _repo.GetAll();

                if (allCategories == null || !allCategories.Any())
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(allCategories.Select(c => c.Name).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return StatusCode(500);
            }
        }
    }
}