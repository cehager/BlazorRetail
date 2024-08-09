using BlazorRetail.Data;
using BlazorRetail.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorRetail.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
               return (await _db.SaveChangesAsync() > 0);
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null) {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var catFromDb = await _db.Categories.FirstOrDefaultAsync( c => c.Id == category.Id);
            if (catFromDb != null)
            {
                catFromDb.Name = category.Name;
                _db.Categories.Update(catFromDb);
                 await _db.SaveChangesAsync();
                return catFromDb;
            }
            return category;
        }
    }
}
