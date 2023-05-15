using Zoo.Models;

namespace Zoo.DAL.AnimalRepository
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> Animals { get; }
        IEnumerable<Comment> Comments { get; }
        Task AddComment(int animalId, Comment comment);
        Task<Animal?> GetAnimal(int id);
    }
}
