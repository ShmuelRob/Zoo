using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using Zoo.DAL.AdminRepository;
using Zoo.Models;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {

        readonly IAdminRepository repository;
        public AdminController(IAdminRepository repository)
            => this.repository = repository;

        [HttpGet("categories")]
        public IActionResult GetCategories() =>
            Ok(repository.Categories.Select(c => new { c.CategoryId, c.Name }));

        [HttpGet("categories/{id}")]
        public IActionResult? GetAnimalsByCategoryId(int id)
        {
            var category = repository.Categories.SingleOrDefault(c => c.CategoryId == id);
            return category is null ? NotFound() : Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory([FromBody]string categoryName)
        {
            if (categoryName is null) return NotFound();
            await repository.AddCategory(new Category { Name = categoryName });
            return Ok();
        }

        [HttpGet("animals/{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = repository.Animals.FirstOrDefault(a => a.AnimalId == id);
            return animal is null? NotFound() : Ok(animal);
        }

        [HttpPost("animals")]
        public async Task<IActionResult> CreateAnimal([FromBody]Animal animal)
        {
            await repository.AddAnimal(animal);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAnimal(int id, [FromBody] Animal edited)
        {
            var animal = new Animal
            {
                CategoryId = edited.CategoryId,
                Age = edited.Age,
                Description = edited.Description,
                ImageSource = edited.ImageSource,
                Name = edited.Name
            };
            await repository.EditAnimal(id, animal);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            if (!await repository.DeleteAnimal(id)) return NotFound();
            return Ok();
        }
    }
}
