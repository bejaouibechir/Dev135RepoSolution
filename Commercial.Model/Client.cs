using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercial.Model
{
    public class Client
    {
        public Client()
        {
                Contacts = new HashSet<Contact>();
                Ventes = new HashSet<Vente>();
                Parrainés = new HashSet<Client>();    
        }
        public string Code { get; set; } // 1111/11 où 11 est le code de société
        public string Nom { get; set; }

        public string Adresse { get; set; }

        public DateTime Naissance { get; set; }

        public long CIN { get; set; } //Carte d'identité nationale qui sert dans les opérations de recherches

        public DateTime  DateCIN { get; set;}

        public string LieuCIN { get; set; }

        //Clé étrangère
        public string ParrainId { get; set; }

        public string Observation { get; set; }

        public DateTime Modification { get; set; } = DateTime.Now;

        //Clé étrangère 
        public int SociétéId { get; set; }

        //Propriété de naviguation
        public virtual Société Société{ get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<Vente> Ventes { get; set; }

        public virtual ICollection<Client> Parrainés { get; set; }

        public virtual Client Parrain { get; set; }

    }
}
