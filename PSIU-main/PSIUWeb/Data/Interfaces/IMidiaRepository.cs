using PSIUWeb.Models;

namespace PSIUWeb.Data.Interfaces
{
    public interface IMidiaRepository
    {
        public Midia GetMidiaById(int id);
        public IQueryable<Midia> GetMidias();
        public Midia Update(Midia m);
        public Midia Delete(int id);
        public Midia Create(Midia m);
    }
}
