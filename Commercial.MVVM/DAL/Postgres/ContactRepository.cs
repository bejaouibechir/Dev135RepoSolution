using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
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
            _context.Add(entity);
        }

        public void Delete(Contact entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Contact> GetAll()
        {
            var data = _context.ListContact();
            var result = new ObservableCollection<Contact>(data);
            return result;
        }

        public Contact Get(int id)
        {
            Contact current = _context.GetContact(id);
            return current;
        }

        public void Update(Contact entity)
        {
            if (Get(entity.Code) != null)
                _context.Update(entity);
            else
                return;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
