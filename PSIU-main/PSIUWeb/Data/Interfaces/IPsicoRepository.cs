using PSIUWeb.Models;

namespace PSIUWeb.Data.Interfaces
{
    public interface IPsicoRepository
    {       
        public Psico GetPsicoById(int id);
        public IQueryable<Psico> GetPsicos();
        public Psico Update(Psico ps);
        public Psico Delete(int id);
        public Psico Create(Psico ps);
    }
}