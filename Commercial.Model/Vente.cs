using System;
using System.Collections.Generic;

namespace Commercial.Model
{
    public class Vente
    {

        public Vente()
        {
            Articles= new HashSet<Article>();
            Paiements = new HashSet<Paiement>();
        }
        public long Code { get; set; }
        public int Tranches { get; set; }

        public decimal Total { get; set; }

        public decimal Payé { get; set; }

        public decimal Reste { get; set; } // Total - payé = reste 

        public DateTime PremièreEchéance { get; set; }
        public DateTime DernièreEchéance { get; set; }

        public string Observation { get; set; }
        public string Modification { get; set; }

        //Clé étrangère
        public string ClientId { get; set; }

        //Propriété de naviguation 
        public virtual Client Client { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Paiement> Paiements { get; set; }

    }
}
