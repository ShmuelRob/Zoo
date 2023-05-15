using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoo.DAL.AnimalRepository;
using Zoo.Models;

namespace Zoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        readonly IAnimalRepository repository;
        public AnimalController(IAnimalRepository repository)
            => this.repository = repository;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await repository.GetAnimal(id);
            if (animal is null) return NotFound();
            return Ok(animal);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateComment(int id, [FromBody] Comment comment)
        {
            var animal = await repository.GetAnimal(id);
            if (animal is null) return NotFound();
            if (comment is null) return NotFound();
            if (comment.Content is null) return NotFound();
            var newComment = new Comment
            {
                AnimalId = id,
                AnimalCommented = animal,
                Content = comment.Content,
                Visitor = comment.Visitor
            };
            await repository.AddComment(id, newComment);
            animal.Comments!.Add(newComment);
            return Ok(animal);
        }
    }
}
