using PSIUWeb.Models;

namespace PSIUWeb.Data.Interfaces
{
    public interface IPacientRepositor
    {
        public Pacient GetPacientById(int id);
        public IQueryable<Pacient> GetPacients();
        public Pacient Update(Pacient p);
        public Pacient Delete(int id);
        public Pacient Create(Pacient p);
    }
}
