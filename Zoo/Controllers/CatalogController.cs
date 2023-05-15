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

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            var category = repository.GetCategory(id);
            category ??= repository.GetCategory(1);
            return new JsonResult(category);
        }
    }
}
