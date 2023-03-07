using System.Collections.Generic;

namespace ConsoleApp.DAO
{
    public interface IClient
    {
        object Historique { get; set; }
        int Id { get; set; }
        string Nom { get; set; }
        ICollection<Vente> Ventes { get; set; }
    }
}