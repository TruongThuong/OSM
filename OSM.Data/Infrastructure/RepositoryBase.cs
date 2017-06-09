using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace OSM.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        private AppsDbContext _context;

        // Hung Ly
        //private DbSet<T> entities;

        #region Properties

        public RepositoryBase(AppsDbContext context)
        {
            _context = context;
            //if (_context == null)
            //{
            //    throw new ArgumentNullException("Context");
            //}
            // Hung Ly
            //entities = context.Set<T>();
        }

        #endregion Properties

        #region Implement IResository Methods

        public virtual void Add(T entity)
        {
            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            //_context.Set<T>().Add(entity);

            _context.Set<T>().Add(entity);
            //_context.Add(entity);
            //if (entity == null)
            //{
            //    throw new ArgumentNullException("entity");
            //}

            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            //if (dbEntityEntry.State != (EntityState)EntityState.Detached)
            //{
            //    dbEntityEntry.State = EntityState.Added;
            //}
            //else
            //{
            //    _context.Set<T>().Add(entity);
            //}
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);

            //if (entity == null)
            //{
            //    throw new ArgumentNullException("entity");
            //}

            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);

            //if (dbEntityEntry.State != (EntityState)EntityState.Detached)
            //{
            //    _context.Set<T>().Attach(entity);
            //}
            //dbEntityEntry.State = EntityState.Modified;
        }

        // Hung Ly
        public virtual void Delete(T entity)
        {
            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            //dbEntityEntry.State = EntityState.Deleted;

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            EntityEntry dbEntityEntry = _context.Entry<T>(entity);

            if (dbEntityEntry.State != (EntityState)EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetSingle(id);

            if (entity == null) return;

            Delete(entity);
        }

        //  200
        public void DeleteMulti(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        // 200
        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        // 200
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(int id)
        {
            // kiem tra ham EntityBase
            //  return _context.Set<T>().FirstOrDefault(x => x.Id == id);
            return _context.Set<T>().Find(id);
        }

        //  200
        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        //  200
        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }
        //200
        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        // 200
        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        //  200
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        //  200
        public void Commit()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        #endregion Implement IResository Methods
    }
}