using Zoo.Models;

namespace Zoo.DAL.CatalogRepository
{
    public interface ICatalogRepository
    {
        IEnumerable<Category> Categories { get; }
        Task<Category?> GetCategory(int id);
    }
}
