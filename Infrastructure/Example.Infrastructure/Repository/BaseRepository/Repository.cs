using Example.Application.Contracts;
using Example.Domain.Common;
using Example.Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infrastructure.Repository.BaseRepository
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>  where T : BaseEntity
    {
        #region Fields
        private readonly IExampleContext _context;
        private readonly IMongoCollection<T> _collection;
        #endregion

        #region Constructor
        public Repository(IExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _collection = _context.Database.GetCollection<T>(GetCollectionName(typeof(T)));
        } 
        #endregion

        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public bool DeleteById(string id)
        {
            ObjectId objectId = new ObjectId(id);
            DeleteResult deleteResult = _collection.DeleteOne(x => x.Id == objectId);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            ObjectId objectId = new ObjectId(id);
            DeleteResult deleteResult = await _collection.DeleteOneAsync(x => x.Id == objectId);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public bool DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            DeleteResult deleteResult = _collection.DeleteMany(filterExpression);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            DeleteResult deleteResult = await _collection.DeleteManyAsync(filterExpression);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public bool DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            DeleteResult deleteResult = _collection.DeleteOne(filterExpression);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            DeleteResult deleteResult = await _collection.DeleteOneAsync(filterExpression);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).ToListAsync();
        }

        public async Task<IEnumerable<TProjected>> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            return await _collection.Find(filterExpression).Project(projectionExpression).ToListAsync();
        }

        public T FindById(string id)
        {
            var objectId = new ObjectId(id);
            return _collection
                    .Find(p => p.Id == objectId)
                    .FirstOrDefault();
        }

        public async Task<T> FindByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection
                          .Find(p => p.Id == objectId)
                          .FirstOrDefaultAsync();
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return _collection
                        .Find(filterExpression)
                        .FirstOrDefault();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection
                            .Find(filterExpression)
                            .FirstOrDefaultAsync();
        }

        public void InsertMany(ICollection<T> documents)
        {
            _collection.InsertMany(documents);
        }

        public async Task InsertManyAsync(ICollection<T> documents)
        {
           await _collection.InsertManyAsync(documents);
        }

        public void InsertOne(T document)
        {
            _collection.InsertOne(document);
        }

        public async Task InsertOneAsync(T document)
        {
            await _collection.InsertOneAsync(document);
        }

        public bool Update(T document)
        {
            var updateResult = _collection.ReplaceOne(filter: g => g.Id == document.Id, replacement: document);

            return updateResult.IsAcknowledged &&
                       updateResult.MatchedCount > 0;
        }

        public async Task<bool> UpdateAsync(T document)
        {
            var updateResult = await _collection.ReplaceOneAsync(filter: g => g.Id == document.Id, replacement: document);

            return updateResult.IsAcknowledged &&
                       updateResult.MatchedCount > 0;
        }

        #region Private Method
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        } 
        #endregion

    }
}
