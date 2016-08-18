using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DentApp.Domain.Interfaces.Repository;
using DentApp.Infra.Data.Context;
using MongoDB.Driver;

namespace DentApp.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected MongoDBContext _mongoDBContext;
        protected IMongoCollection<TEntity> _collection;        

        public BaseRepository(MongoDBContext context)
        {
            _mongoDBContext = context;            
        }

        protected void SetCollection(string collectionName)
        {
            _collection = _mongoDBContext.DataBase.GetCollection<TEntity>(collectionName);
        }

        public TEntity Add(TEntity obj)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).SingleOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {         
            GC.SuppressFinalize(this);
        }
    }
}
