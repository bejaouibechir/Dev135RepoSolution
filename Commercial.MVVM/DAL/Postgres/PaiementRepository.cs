using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
{
    public class PaiementRepository : IRepository<Paiement, long>
    {
        CommercialContext _context;

        public PaiementRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Paiement entity)
        {
            _context.Add(entity);
        }

        public void Delete(Paiement entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Paiement> GetAll()
        {
            var data = _context.ListPaiement();
            var result = new ObservableCollection<Paiement>(data);
            return result;
        }

        public Paiement Get(long id)
        {
            Paiement current = _context.GetPaiement(id);
            return current;
        }

        public void Update(Paiement entity)
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
