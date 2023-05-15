using Zoo.Models;

namespace Zoo.DAL.AdminRepository
{
    public interface IAdminRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Animal> Animals { get; }
        Task AddCategory(Category category);
        Task AddAnimal(Animal animal);
        Task EditAnimal(int id, Animal animal);
        Task<bool> DeleteAnimal(int id);
    }
}
