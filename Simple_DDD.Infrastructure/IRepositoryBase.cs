using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simple_DDD.Infrastructure
{
    public interface IRepositoryBase<T>  where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(List<Expression<Func<T, bool>>> expressions);
        IQueryable<T> FindByConditionWithPaging(Expression<Func<T, bool>> expression, int pageNumber, int pageSize, out int totalCount);
        IQueryable<T> FindByConditionWithPagingOrder(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize, out int totalCount);
        IQueryable<T> FindByConditionWithPagingOrder(List<Expression<Func<T, bool>>> expressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize, out int totalCount);
        IQueryable<T> FindByConditionWithPagingOrder(List<Expression<Func<T, bool>>> expressions, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize);
        IQueryable<T> FindByConditionWithPagingOrder(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int pageNumber, int pageSize);
       void Create(T entity);
       Task CreateAsync(T entity);
       void Update(T entity);
       void Delete(T entity);
       void DeleteRange(List<T> entity);
       void AddRange(List<T> entities);
       void UpdateRange(List<T> entities);
       void Clear();
    }
}