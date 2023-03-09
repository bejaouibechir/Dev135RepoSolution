using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Commercial.MVVM.DAL
{
    public interface IRepository<T,U>
    {
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        T Get(U id);
        ObservableCollection<T> GetAll();
        void Save();
    }
}
