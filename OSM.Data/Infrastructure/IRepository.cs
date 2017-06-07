using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace OSM.Data.Infrastructure
{
    public interface IRepository<T> where T : class, new()
    {
        // Hung Ly
        void Add(T entity);
        void Update(T entity);

        // Hung Ly
        void Delete(T entity);

        IDbContextTransaction BeginTransaction();

        void Delete(int id);

        void DeleteMulti(Expression<Func<T, bool>> predicate);

        //void DeleteWhere(Expression<Func<T, bool>> predicate);

        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll();

        // New
        IEnumerable<T> GetAll(string[] includes = null);

        //New
        IEnumerable<T> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);

        T GetSingle(int id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        //New
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        //New
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        //New
        int Count();

        //New
        int Count(Expression<Func<T, bool>> where);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        //New
        bool CheckContains(Expression<Func<T, bool>> predicate);

        // Da su dung o day can gi toi UnitOfWork
        void Commit();
    }
}