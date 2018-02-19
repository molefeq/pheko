using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Pheko.DataAccess.Repository.Classes
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal PhekoEntities _Context;
        internal DbSet<TEntity> _DbSet;

        public GenericRepository(PhekoEntities context)
        {
            _Context = context;
            _DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                query = Include(query, includeProperties);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            IQueryable<TEntity> query = _DbSet;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                query = Include(query, includeProperties);
            }

            return query.Where(filter).FirstOrDefault<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _DbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _DbSet.Attach(entityToDelete);
            }
            _DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (_Context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _DbSet.Attach(entityToUpdate);
            }

            _Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, string includeList)
        {
            foreach (var includeProperty in includeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
        
        public virtual void Dispose()
        {
            _Context.Dispose();
        }
    }
}
