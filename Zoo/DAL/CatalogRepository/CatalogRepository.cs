using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.DAL.CatalogRepository
{
    public class CatalogRepository : ICatalogRepository
    {
        readonly ZooDbContext context;
        public CatalogRepository(ZooDbContext context) => this.context = context;
        public virtual IEnumerable<Category> Categories => context.Categories!
            .Include(c => c.Animals)!.ThenInclude(a => a.Comments);

        public async Task<Category?> GetCategory(int id) =>
            await Task.Run(() => Categories.SingleOrDefault(c => c.CategoryId == id));
    }
}
