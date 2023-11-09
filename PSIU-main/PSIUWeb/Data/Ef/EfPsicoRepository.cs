using PSIUWeb.Data.Interfaces;
using PSIUWeb.Models;
using System.Linq;


namespace PSIUWeb.Data.Ef
{
    public class EfPsicoRepository : IPsicoRepository
    {
        private AppDbContext context;

        public EfPsicoRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Psico Create(Psico ps)
        {
            try
            {
                context.Psicos?.Add(ps);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return ps;
        }

        public Psico Delete(int id)
        {
            Psico? ps = GetPsicoById(id);
            if (ps == null)
                return null;
            context.Psicos?.Remove(ps);
            context.SaveChanges();

            return ps;
        }

        public Psico GetPsicoById(int id)
        {
            Psico? ps = context.Psicos.
                Where(ps => ps.Id == id).FirstOrDefault();
            return ps;
        }

        public IQueryable<Psico> GetPsicos()
        {
            return context.Psicos;
        }

        public Psico Update(Psico ps)
        {
            try
            {
                context.Psicos?.Update(ps);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return ps;
        }
    }
}