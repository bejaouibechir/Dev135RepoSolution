using System;

namespace Commercial.Model
{
    public class Article
    {
        public int Code { get; set; }
        public string Designation { get; set; }

        public decimal Montant { get; set; }
        public string Observation { get; set; }
        public DateTime Modification { get; set; } = DateTime.Now;

        //Clé étrangère
        public long VenteId { get; set; }

        //Propriété de naviguation
        public virtual Vente Vente { get; set; }
    }
}
