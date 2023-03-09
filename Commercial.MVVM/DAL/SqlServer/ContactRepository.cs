using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
{
    public class ContactRepository : IRepository<Contact, int>
    {
        CommercialContext _context;

        public ContactRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Contact entity)
        {
            _context.Contacts.Add(entity);
        }

        public void Delete(Contact entity)
        {
            if (Get(entity.Code) != null)
                _context.Contacts.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Contact> GetAll()
        {
            var data = _context.Contacts.AsEnumerable();
            var result = new ObservableCollection<Contact>(data);
            return result;
        }

        public Contact Get(int id)
        {
            Contact current = _context.Contacts.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Contact entity)
        {
            if (Get(entity.Code) != null)
                _context.Contacts.AddOrUpdate(entity);
            else
                return;
        }
        public void Save() => _context.SaveChanges();
    }
}
