using Krispy.AccessData.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.AccessData.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext contexto)
        {
            Context = contexto;
            this.dbSet = contexto.Set<T>();
        }

        public bool Add(T entity)
        {
            dbSet.Add(entity);
            return Complete();
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            return Complete();
        }

        public bool Update(T entity)
        {
            dbSet.Update(entity);
            return Complete();
        }

        public bool Delete(int id)
        {
            T entityToRemove = dbSet.Find(id);
            dbSet.Remove(entityToRemove);
            return Complete();
        }

        public bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return Complete();
        }

        public bool DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return Complete();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(string id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public bool Exists(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.Any();
        }

        public bool Active(int id)
        {
            T entity = dbSet.Find(id);

            if (entity != null)
            {
                Type t = entity.GetType();

                PropertyInfo info = t.GetProperty("Activo");
                if (info != null)
                {
                    info.SetValue(entity, true);
                    dbSet.Update(entity);
                    return Complete();
                }
            }
            return false;

        }

        public bool Inactive(int id)
        {
            T entity = dbSet.Find(id);

            if (entity != null)
            {
                Type t = entity.GetType();

                PropertyInfo info = t.GetProperty("Activo");
                if (info != null)
                {
                    info.SetValue(entity, false);
                    dbSet.Update(entity);
                    return Complete();
                }
            }
            return false;
        }

        public bool Complete()
        {
            return Context.SaveChanges() >= 0 ? true : false;

        }


    }
}
