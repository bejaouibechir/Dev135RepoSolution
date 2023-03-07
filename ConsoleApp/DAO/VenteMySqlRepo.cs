using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class VenteMySqlRepo : IRepository<Vente, int>
    {
        public void Add(Vente entity)
        {
            ;
        }

        public void Delete(Vente entity)
        {
            ;
        }

        public Vente Get(int id)
        {
            return null;
        }

        public ObservableCollection<Vente> GetAll()
        {
            return null;
        }

        public void Update(Vente entity)
        {
            ;
        }
    }
}
