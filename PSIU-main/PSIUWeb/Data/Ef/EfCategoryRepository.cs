using PSIUWeb.Data.Interfaces;
using PSIUWeb.Models;

namespace PSIUWeb.Data.Ef
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private AppDbContext context;

        public EfCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category Create(Category c)
        {
            try
            {
                context.Categories?.Add(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }

        public Category Delete(int id)
        {
            Category? c = GetCategoryById(id);
            if (c == null)
                return null;
            context.Categories?.Remove(c);
            context.SaveChanges();

            return c;
        }

        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Category GetCategoryById(int id)
        {
            Category c = context.Categories.
                Where(c => c.Id == id).FirstOrDefault();
            return c;
        }

        public Category Update(Category c)
        {
            try
            {
                context.Categories?.Update(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }
    }
}
