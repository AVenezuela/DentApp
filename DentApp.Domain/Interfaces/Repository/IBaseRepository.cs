using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq.Expressions;
using DentApp.Domain.Entities;

namespace DentApp.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(ObjectId id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity obj);
        void Delete(TEntity obj);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate);
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
