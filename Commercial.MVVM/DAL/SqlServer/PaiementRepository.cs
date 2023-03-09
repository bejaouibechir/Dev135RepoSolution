using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class PaiementRepository : IRepository<Paiement, long>
    {
        CommercialContext _context;

        public PaiementRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Paiement entity)
        {
            _context.Paiements.Add(entity);
        }

        public void Delete(Paiement entity)
        {
            if (Get(entity.Code) != null)
                _context.Paiements.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Paiement> GetAll()
        {
            var data = _context.Paiements.AsEnumerable();
            var result = new ObservableCollection<Paiement>(data);
            return result;
        }

        public Paiement Get(long id)
        {
            Paiement current = _context.Paiements.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Paiement entity)
        {
            if (Get(entity.Code) != null)
                _context.Paiements.AddOrUpdate(entity);
            else
                return;
        }
        public void Save() => _context.SaveChanges();
    }
}
