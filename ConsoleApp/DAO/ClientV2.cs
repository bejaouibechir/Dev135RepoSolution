using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class ClientV2<T> :IClient
    {
        public ClientV2()
        {
            Ventes = new HashSet<Vente>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public T Historique { get; set; }

        public int Fidélité { get; set; }

        public ClientV2<T> Parin { get; set; }

        public ICollection<ClientV2<T>> Parainés { get; set; }

        //Propriété de naviguation
        public ICollection<Vente> Ventes { get; set; }
        object IClient.Historique { get; set; }
    }
}
