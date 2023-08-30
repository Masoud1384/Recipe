using System.Linq.Expressions;

namespace Domain
{
    public interface IRepository<T,TKey> where T : class
    {
        T Get(TKey id);

        List<T> Get();

        void Create(T entity);

        bool Exists(Expression<Func<T, bool>> expression);

        void SaveChanges();
    }
}
