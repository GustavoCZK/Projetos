using PSIUWeb.Models;

namespace PSIUWeb.Data.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategoryById(int id);
        public IQueryable<Category> GetCategories();
        public Category Update(Category p);
        public Category Delete(int id);
        public Category Create(Category p);
    }
}