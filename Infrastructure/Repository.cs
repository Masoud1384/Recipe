using Domain;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly Context _context;

        public RepositoryBase(Context context)
        {
            _context = context;
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TKey Get(T id)
        {
            throw new NotImplementedException();
        }

        public void Create(TKey entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TKey, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
