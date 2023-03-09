using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class ResponsableRepository : IRepository<Responsable, int>
    {
        CommercialContext _context;

        public ResponsableRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Responsable entity)
        {
            _context.Responsables.Add(entity);
        }

        public void Delete(Responsable entity)
        {
            if (Get(entity.Code) != null)
                _context.Responsables.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Responsable> GetAll()
        {
            var data = _context.Responsables.AsEnumerable();
            var result = new ObservableCollection<Responsable>(data);
            return result;
        }

        public Responsable Get(int id)
        {
            Responsable current = _context.Responsables.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Responsable entity)
        {
            if (Get(entity.Code) != null)
                _context.Responsables.AddOrUpdate(entity);
            else
                return;
        }
        public void Save() => _context.SaveChanges();
    }
}
