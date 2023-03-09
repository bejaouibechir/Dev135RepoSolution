using Commercial.Model;
using System.Collections.ObjectModel;
using Commercial.SqlServer;
using System.Windows.Navigation;
using System.Linq;
using System.Data.Entity.Migrations;

namespace Commercial.MVVM.DAL.SqlServer
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
            _context.Articles.Add(entity);
        }

        public void Delete(Article entity)
        {
            if (Get(entity.Code) != null)
                _context.Articles.Remove(entity);
            else
                return;
        }

        public ObservableCollection<Article> GetAll()
        {
            var data = _context.Articles.AsEnumerable();
            var result = new ObservableCollection<Article>(data);
            return result;
        }

        public Article Get(int id)
        {
            Article current = _context.Articles.SingleOrDefault(s=>s.Code== id);
            return current;
        }

        public void Update(Article entity)
        {
            if (Get(entity.Code) != null)
                _context.Articles.AddOrUpdate(entity);
            else
                return;
        }
        public void Save() => _context.SaveChanges();
    }
}
