using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.DAL.Catalog
{
    public class CatalogRepository : ICatalogRepository
    {
        readonly ZooDbContext context;
        public CatalogRepository(ZooDbContext context) => this.context = context;
        public virtual IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);

        public Category? GetCategory(int id) =>
            Categories.SingleOrDefault(c => c.CategoryID == id);
    }
}
