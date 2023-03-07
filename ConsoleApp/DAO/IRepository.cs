using System.Collections.ObjectModel;

namespace ConsoleApp.DAO
{
    public interface IRepository<T,U> // T représenter => le client ou/et la vente
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(U id);
        ObservableCollection<T> GetAll();
           
    }
}
