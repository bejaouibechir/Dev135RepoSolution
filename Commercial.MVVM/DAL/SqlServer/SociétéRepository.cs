using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class SociétéRepository : IRepository<Société, int>
    {
        CommercialContext _context;

        public SociétéRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Société entity)
        {
            _context.Sociétés.Add(entity);
        }

        public void Delete(Société entity)
        {
            if (Get(entity.Code) != null)
                _context.Sociétés.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Société> GetAll()
        {
            var data = _context.Sociétés.AsEnumerable();
            var result = new ObservableCollection<Société>(data);
            return result;
        }

        public Société Get(int id)
        {
            Société current = _context.Sociétés.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Société entity)
        {
            if (Get(entity.Code) != null)
                _context.Sociétés.AddOrUpdate(entity);
            else
                return;
        }

        public void Save() => _context.SaveChanges();
    }
}
