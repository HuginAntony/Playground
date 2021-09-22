using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MongoDbDataAccess
{
    public abstract class MongoRepository<TEntity>
        where TEntity : class
    {
        private readonly MongoClient _mongoClient;
        protected readonly IMongoCollection<TEntity> Collection;

        protected MongoRepository(IMongoDatabaseSettings mongoSettings, string dbName, string collectionName)
        {
            _mongoClient = new MongoClient(mongoSettings.ConnectionString);
            
            var database = _mongoClient.GetDatabase(dbName);
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> updateDefinition)
        {
            var result = await Collection.UpdateOneAsync(predicate, updateDefinition);
            return result.ModifiedCount > 0;
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await Collection.FindAsync(predicate);
            return await result.ToListAsync();
        }

        public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await Collection.FindAsync(predicate);
            return await result.FirstOrDefaultAsync();
        }

        public IMongoQueryable<TEntity> LazyGetAll()
        {
            return Collection.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Collection.AsQueryable().AsEnumerable();
        }

        public IMongoQueryable<TEntity> LazyGet(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.AsQueryable().Where(predicate);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.AsQueryable()
                             .Where(predicate)
                             .AsEnumerable();

        }

        public async Task InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await Collection.InsertManyAsync(entities);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await Collection.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }
    }
}