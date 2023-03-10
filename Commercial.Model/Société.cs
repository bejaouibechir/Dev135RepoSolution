using System;
using System.Collections.Generic;
namespace Commercial.Model
{
    public class Société
    {
        public Société()
        {
            Responsables= new HashSet<Responsable>();
            Clients = new HashSet<Client>();
        }
        
        public int Code { get; set; }
        public string Raison { get; set; }
        public int? NombreClients { get; set; }
        public decimal? Chiffre_Affaires { get; set; }
        public decimal? Dettes { get; set; }
        public string Image { get; set; }
        public string Observation { get; set; }
        public DateTime? Modification { get; set; } = DateTime.Now;
   
        //Propriétés de naviguation
        public virtual ICollection<Responsable> Responsables { get; set; }
        public virtual ICollection<Client> Clients { get; set; }


    }
}
