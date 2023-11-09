using PSIUWeb.Data.Interfaces;
using PSIUWeb.Models;

namespace PSIUWeb.Data.Ef
{
    public class EfMidiaRepository : IMidiaRepository
    {

        private AppDbContext context;

        public EfMidiaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Midia Create(Midia m)
        {
            try
            {
                context.Midias?.Add(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }

        public Midia Delete(int id)
        {
            Midia? m = GetMidiaById(id);
            if (m == null)
                return null;
            context.Midias?.Remove(m);
            context.SaveChanges();

            return m;
        }

        public IQueryable<Midia> GetMidias()
        {
            return context.Midias;
        }

        public Midia GetMidiaById(int id)
        {
            Midia m = context.Midias.
                Where(m => m.Id == id).FirstOrDefault();
            return m;
        }

        public Midia Update(Midia m)
        {
            try
            {
                context.Midias?.Update(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }
    }
}
