using System;

namespace Commercial.Model
{
    public class Paiement
    {
        public long Code { get; set; }
        public string CodeClient { get; set; }

        public decimal Tranche { get; set; }

        public decimal Avance { get; set; }

        public decimal Reste { get; set; }
        public DateTime Echéance { get; set; }

        public DateTime DateEffective { get; set; }

        public string TypePaiment { get; set; }

        public DateTime Modification { get; set; }

        //Clé étrangère
        public long VenteId { get; set; }

        //Propriété de naviguation
        public virtual Vente Vente { get; set; }

    }
}
