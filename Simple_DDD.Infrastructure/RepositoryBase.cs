using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_DDD.Infrastructure.Context;

namespace Simple_DDD.Infrastructure
{
     public  class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private ApplicationDbContext  RepositoryContext { get; set; }

        public RepositoryBase(ApplicationDbContext _repositoryContext)
        {
            RepositoryContext = _repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            expression ??= x => true;
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> FindByCondition(List<Expression<Func<T, bool>>> expressions)
        {
            var query = RepositoryContext.Set<T>().AsQueryable();
            expressions.ForEach(x => query = query.Where(x));
            return query.AsNoTracking();
        }

        public IQueryable<T> FindByConditionWithPaging(Expression<Func<T, bool>> expression, int pageNumber, int pageSize, out int totalCount)
        {
            expression ??= x => true;

            totalCount = RepositoryContext.Set<T>().Where(expression).AsNoTracking().Count();
            return RepositoryContext.Set<T>().Where(expression).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking();
        }
        public IQueryable<T> FindByConditionWithPagingOrder(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize, out int totalCount)
        {
            var query = RepositoryContext.Set<T>().AsQueryable();
            totalCount = RepositoryContext.Set<T>().Where(expression).AsNoTracking().Count();
            return orderBy(RepositoryContext.Set<T>().Where(expression)).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking();
        }
        public IQueryable<T> FindByConditionWithPagingOrder(List<Expression<Func<T, bool>>> expressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize, out int totalCount)
        {
            var query = RepositoryContext.Set<T>().AsQueryable();
            expressions.ForEach(x => query = query.Where(x));
            totalCount = query.AsNoTracking().Count();
            query = orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
            return query;
        }
        public IQueryable<T> FindByConditionWithPagingOrder(List<Expression<Func<T, bool>>> expressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize)
        {
            var query = RepositoryContext.Set<T>().AsQueryable();
            expressions.ForEach(x => query = query.Where(x));
            query = orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();

            return query;
        }
        public IQueryable<T> FindByConditionWithPagingOrder(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize)
        {
            var query = RepositoryContext.Set<T>().AsQueryable();
            return orderBy(RepositoryContext.Set<T>().Where(expression)).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking();
        }


        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {

            RepositoryContext.Set<T>().Update(entity);
        }

        // public async Task<int> ExecuteUpdateAsync(Expression<Func<T, bool>> expression, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> propertList)
        // {
        //     return await RepositoryContext.Set<T>().Where(expression).ExecuteUpdateAsync(propertList);
        // }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        // public async Task<int> ExecuteDeleteAsync(Expression<Func<T, bool>> expression)
        // {
        //     return await RepositoryContext.Set<T>().Where(expression).ExecuteDeleteAsync();
        // }

        public void DeleteRange(List<T> entity)
        {
            RepositoryContext.Set<T>().RemoveRange(entity);
        }

        public  void AddRange(List<T> entities)
        {
            RepositoryContext.Set<T>().AddRange(entities);
        }

        public  void UpdateRange(List<T> entities)
        {
            RepositoryContext.Set<T>().UpdateRange(entities);
        }
        
        public  void Clear()
        {
            RepositoryContext.ChangeTracker.Clear();
        }

        // public List<T> FromSqlRaw(string command)
        // {
        //     return RepositoryContext.Set<T>().FromSqlRaw(command).ToList();
        // }


    }
}