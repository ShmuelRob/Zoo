using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.DAL.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        readonly ZooDbContext context;
        static int categoryIndex = 0;
        static int animalIndex = 0;
        public AdminRepository(ZooDbContext context)
        {
            this.context = context;

            var catInd = context.Categories?.ToList().MaxBy(c => c.CategoryId)?.CategoryId;
            if (catInd.HasValue)
                categoryIndex = catInd.Value;

            var anInd = context.Animals?.ToList().MaxBy(a => a.AnimalId)?.AnimalId;
            if (anInd.HasValue)
                animalIndex = anInd.Value;
        }

        public IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);

        public IEnumerable<Animal> Animals =>
            context.Animals!.Include(a => a.Comments);

        public async Task AddCategory(Category category)
        {
            await Task.Run(() =>
            {
                var categoryToAdd = new Category
                {
                    Animals = category.Animals,
                    Name = category.Name,
                    CategoryId = ++categoryIndex
                };
                context.Categories!.Add(categoryToAdd);
                context.SaveChanges();
            });
        }
        public async Task AddAnimal(Animal animal)
        {
            if (animal.Name is null) return;
            await Task.Run(() =>
            {
                var animalToAdd = new Animal
                {
                    AnimalId = ++animalIndex,
                    Name = animal.Name,
                    Age = animal.Age,
                    Category = animal.Category,
                    CategoryId = animal.CategoryId,
                    Comments = animal.Comments,
                    Description = animal.Description,
                    ImageSource = animal.ImageSource,
                };
                context.Animals!.Add(animalToAdd);
                context.SaveChanges();
            });
        }

        public async Task EditAnimal(int id, Animal animal)
        {
            await Task.Run(() =>
            {
                var oldAnimal = context.Animals!.SingleOrDefault(a => a.AnimalId == id);
                
                if (oldAnimal is null) return;
                if (animal.Name is not null) oldAnimal.Name = animal.Name;
                if (animal.Age > 0) oldAnimal.Age = animal.Age;
                if (animal.CategoryId > 0) oldAnimal.CategoryId = animal.CategoryId;
                if (animal.Description is not null) oldAnimal.Description = animal.Description;
                if (animal.ImageSource is not null) oldAnimal.ImageSource = animal.ImageSource;
                context.SaveChanges();
            });
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            return await Task.Run(() =>
            {
                var animal = Animals.SingleOrDefault(a => a.AnimalId == id);
                if (animal is null) return false;
                context.Remove(animal);
                context.SaveChanges();
                return true;
            });
        }
    }
}
