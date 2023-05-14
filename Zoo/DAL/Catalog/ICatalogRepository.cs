using Zoo.Models;

namespace Zoo.DAL.Catalog
{
    public interface ICatalogRepository
    {
        IEnumerable<Category> Categories { get; }
        Category? GetCategory(int id);
    }
}
