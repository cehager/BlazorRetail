using BlazorRetail.Data;
using BlazorRetail.Repository.IRepository;

namespace BlazorRetail.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
               return _db.SaveChanges() > 0;
            }
            return false;
        }

        public Category Get(int id)
        {
            var obj = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (obj == null) {
                return new Category;
            }
            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category Update(Category category)
        {
            var catFromDb = _db.Categories.FirstOrDefault( c => c.Id == category.Id);
            if (catFromDb != null)
            {
                catFromDb.Name = category.Name;
                _db.Categories.Update(catFromDb);
                _db.SaveChanges();
                return catFromDb;
            }
            return category;
        }
    }
}
