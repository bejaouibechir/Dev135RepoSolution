using System.Collections.ObjectModel;

namespace ConsoleApp.Repository
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
