

using System.Linq.Expressions;

namespace Krispy.AccessData.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(string id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );
        bool Exists(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        bool DeleteRange(IEnumerable<T> entities);

        bool Active(int Id);
        bool Inactive(int Id);

        bool Complete();
    }
}

