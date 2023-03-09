using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
{
    public class VenteRepository : IRepository<Vente, long>
    {
        CommercialContext _context;

        public VenteRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Vente entity)
        {
            _context.Add(entity);
        }

        public void Delete(Vente entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Vente> GetAll()
        {
            var data = _context.ListVente();
            var result = new ObservableCollection<Vente>(data);
            return result;
        }

        public Vente Get(long id)
        {
            Vente current = _context.GetVente(id);
            return current;
        }

        public void Update(Vente entity)
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
