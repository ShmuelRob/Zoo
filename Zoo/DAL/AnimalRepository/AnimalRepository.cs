using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.DAL.AnimalRepository
{
    public class AnimalRepository : IAnimalRepository
    {
        readonly ZooDbContext context;
        public AnimalRepository(ZooDbContext context)
            => this.context = context;
        public virtual IEnumerable<Animal> Animals => context.Animals!.Include(a => a.Comments);
        public virtual IEnumerable<Comment> Comments => context.Comments!;
        public Task AddComment(int animalId, Comment comment)
        {
            return Task.Run(() =>
            {
                context.Comments!.Add(comment);
                context.SaveChanges();
            });
        }
        public Task<Animal?> GetAnimal(int id) => Task.Run(() => Animals.SingleOrDefault(a => a.AnimalId == id));
    }
}
