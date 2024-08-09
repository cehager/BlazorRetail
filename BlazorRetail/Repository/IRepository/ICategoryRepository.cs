using BlazorRetail.Data;

namespace BlazorRetail.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Category Create(Category category);
        public Category Update(Category category);
        public Category Delete(int id);
        public Category Get(int id);
        public IEnumerable<Category> GetAll();

    }
}
