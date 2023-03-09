using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
{
    public class SociétéRepository : IRepository<Société, int>
    {
        CommercialContext _context;

        public SociétéRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Société entity)
        {
            _context.Add(entity);
        }

        public void Delete(Société entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Société> GetAll()
        {
            var data = _context.ListSociété();
            var result = new ObservableCollection<Société>(data);
            return result;
        }

        public Société Get(int id)
        {
            Société current = _context.GetSociété(id);
            return current;
        }

        public void Update(Société entity)
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
