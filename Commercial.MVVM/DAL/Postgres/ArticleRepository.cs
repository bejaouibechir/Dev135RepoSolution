using Commercial.Model;
using System.Collections.ObjectModel;
using Commerical.Postgres;
using System;

namespace Commercial.MVVM.DAL.Postgres
{
    public class ArticleRepository : IRepository<Article, int>
    {
        CommercialContext _context;

        public ArticleRepository()
        {
            _context = new CommercialContext();
        }

        public void Add(Article entity)
        {
            _context.Add(entity);
        }

        public void Delete(Article entity)
        {
            if (Get(entity.Code) != null)
                _context.Delete(entity);
            else
                return;
        }

        public ObservableCollection<Article> GetAll()
        {
            var data = _context.ListArticle();
            var result = new ObservableCollection<Article>(data);
            return result;
        }

        public Article Get(int id)
        {
            Article current = _context.GetArticle(id);
            return current;
        }

        public void Update(Article entity)
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
