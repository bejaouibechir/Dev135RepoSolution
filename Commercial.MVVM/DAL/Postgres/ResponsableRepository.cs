using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
{
    public class ResponsableRepository : IRepository<Responsable, int>
    {
        CommercialContext _context;

        public ResponsableRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Responsable entity)
        {
            _context.Add(entity);
        }

        public void Delete(Responsable entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Responsable> GetAll()
        {
            var data = _context.ListResponsable();
            var result = new ObservableCollection<Responsable>(data);
            return result;
        }

        public Responsable Get(int id)
        {
            Responsable current = _context.GetResponsable(id);
            return current;
        }

        public void Update(Responsable entity)
        {
            if (Get(entity.Code) != null)
                _context.Update(entity);
            else
                return;
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
