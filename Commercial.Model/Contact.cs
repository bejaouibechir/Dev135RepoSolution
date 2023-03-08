using System;

namespace Commercial.Model
{
    public class Contact
    {
        public int Code { get; set; }
        public string Téléphone { get; set; }
        public string Mail { get; set; }
        public string Relatif { get; set; }
        public string NomRelatif { get; set; }
        public string Observation { get; set; }
        public DateTime Modification { get; set; } = DateTime.Now;


        //Clé étrangère
        public string ClientId { get; set; }

        //Propriété de naviguation
        public virtual Client Client { get; set; }
    }
}
