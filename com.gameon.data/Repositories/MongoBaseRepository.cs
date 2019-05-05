using com.gameon.data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.gameon.data.Repositories
{
    public class MongoBaseRepository<T> : IDocumentRepository<T>
    {
        private IMongoCollection<T> _collection;

        public MongoBaseRepository(IConfiguration config)
        {
            var dbSettings = config.GetSection("DbSettings");
            var connectionString = dbSettings["ConnectionString"];
            var dbName = dbSettings["DbName"];
            _collection = GetCollection(connectionString, dbName);
        }

        private IMongoCollection<T> GetCollection(string connectionString, string dbName)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(dbName);
                var collectionName = typeof(T).Name;
                return database.GetCollection<T>(collectionName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while attempting to connect to database: {ex}");
            }
        }

        // Crud Methods
        public virtual IFindFluent<T, T> GetAll()
        {
            return _collection.Find(x => true);
        }

        public IFindFluent<T, T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _collection.Find(predicate);
        }

        public async Task Create(T doc)
        {
            try
            {
                await _collection.InsertOneAsync(doc);
            }
            catch (MongoCommandException ex)
            {
                throw new Exception($"Error while creating document: {ex}");
            }
        }
    }
}
