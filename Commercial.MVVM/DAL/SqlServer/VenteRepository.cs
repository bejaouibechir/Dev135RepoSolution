using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class VenteRepository : IRepository<Vente, long>
    {
        CommercialContext _context;

        public VenteRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Vente entity)
        {
            _context.Ventes.Add(entity);
        }

        public void Delete(Vente entity)
        {
            if (Get(entity.Code) != null)
                _context.Ventes.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Vente> GetAll()
        {
            var data = _context.Ventes.AsEnumerable();
            var result = new ObservableCollection<Vente>(data);
            return result;
        }

        public Vente Get(long id)
        {
            Vente current = _context.Ventes.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Vente entity)
        {
            if (Get(entity.Code) != null)
                _context.Ventes.AddOrUpdate(entity);
            else
                return;
        }

        public void Save() => _context.SaveChanges();
    }
}
