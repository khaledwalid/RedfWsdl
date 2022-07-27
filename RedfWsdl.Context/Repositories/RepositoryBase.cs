using System;
using System.Linq;
using System.Linq.Expressions;
using RedfWsdl.Context.Context;
using RedfWsdl.Context.Interfaces;

namespace RedfWsdl.Context.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RedfWsdlDbContext _repositoryContext;

        public RepositoryBase(RedfWsdlDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => _repositoryContext.Set<T>().AsQueryable();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _repositoryContext.Set<T>().Where(expression);
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
    }
}