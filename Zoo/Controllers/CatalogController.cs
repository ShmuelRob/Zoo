using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.DAL.CatalogRepository;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        readonly ICatalogRepository repository;
        public CatalogController(ICatalogRepository repository)
            => this.repository = repository;

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = repository.Categories.Select(c => new { c.Name, c.CategoryId });
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = repository.GetCategory(id);
            category ??= repository.GetCategory(1);
            return Ok(category);
        }
    }
}
