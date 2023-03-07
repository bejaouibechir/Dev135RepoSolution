using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class Client
    {
        public Client()
        {
            Ventes = new HashSet<Vente>();
        }
        
        public int Id { get; set; }
        public string Nom { get; set; }
        public object Historique { get; set; }



        //Propriété de naviguation
        public ICollection<Vente> Ventes { get; set; }
    }
}
