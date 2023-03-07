using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public class Vente
    {
        public int Id { get; set; }
        public DateTime DateVente { get; set; }

        //Clé étrangère
        public int ClientId { get; set; }
        //Propriété de naviguation
        public Client Client { get; set; }
    }
}
