namespace Commercial.Model
{
    public class Responsable
    {
        public int Code { get; set; }
        public string Nom { get; set; }
        public string Contact { get; set; }

        //Clé étrangère
        public int SociétéId { get; set; }

        //Propriété de naviguation
        public virtual Société Société { get; set; }
    }
}
