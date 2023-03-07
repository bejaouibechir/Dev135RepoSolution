using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repository
{
    public class ClientSqlServerRepo : IRepository<Client, string>
    {
        public void Add(Client entity)
        {
            ;
        }

        public void Delete(Client entity)
        {
            ;
        }

        public Client Get(string id)
        {
            return null;
        }

        public ObservableCollection<Client> GetAll()
        {
            return null;
        }

        public void Update(Client entity)
        {
            ;
        }
    }
}
