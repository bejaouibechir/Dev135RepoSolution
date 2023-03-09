using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System.Linq;
using System.Data.Entity.Migrations;
using System;

namespace Commercial.MVVM.DAL.Postgres
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
            _context.Add(entity);
        }

        public void Delete(Client entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Client> GetAll()
        {
            var data = _context.ListClient();
            var result = new ObservableCollection<Client>(data);
            return result;
        }

        public Client Get(string id)
        {
            Client current = _context.GetClient(id);
            return current;
        }

        public void Update(Client entity)
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
