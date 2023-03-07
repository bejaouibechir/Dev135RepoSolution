using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class ClientMySqlRepo : IRepository<IClient, string>
    {
        public void Add(IClient entity)
        {
            ;
        }

        public void Delete(IClient entity)
        {
            ;
        }

        public IClient Get(string id)
        {
            return null;
        }

        public ObservableCollection<IClient> GetAll()
        {
            return null;
        }

        public void Update(IClient entity)
        {
            ;
        }
    }
}
