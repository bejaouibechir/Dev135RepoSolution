using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class ClientRepository : IRepository<Client, string> 
    {
        CommercialContext _context;

        public ClientRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Client entity)
        {
            _context.Clients.Add(entity);
        }

        public void Delete(Client entity)
        {
            if (Get(entity.Code) != null)
                _context.Clients.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Client> GetAll()
        {
            var data = _context.Clients.AsEnumerable();
            var result = new ObservableCollection<Client>(data);
            return result;
        }

        public Client Get(string id)
        {
            Client current = _context.Clients.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Client entity)
        {
            if (Get(entity.Code) != null)
                _context.Clients.AddOrUpdate(entity);
            else
                return;
        }
        public void Save() => _context.SaveChanges();
    }
}
