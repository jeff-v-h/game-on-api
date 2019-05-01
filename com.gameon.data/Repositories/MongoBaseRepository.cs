using com.gameon.data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace com.gameon.data.Repositories
{
    public class MongoBaseRepository<T> : IDocumentRepository<T>
    {
        private readonly IConfiguration _config;
        private IMongoDatabase _database;
        private IMongoCollection<T> _collection;

        public MongoBaseRepository(IConfiguration config)
        {
            _config = config;

            var dbSettings = _config.GetSection("DbSettings");
            var connectionString = dbSettings["ConnectionString"];
            var dbName = dbSettings["DbName"];

            Connect(connectionString, dbName);

            var collectionName = typeof(T).Name;
            _collection = _database.GetCollection<T>(collectionName);
        }

        public void Connect(string connectionString, string dbName)
        {
            try
            {
                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(dbName);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while attempting to connect to database: {e}");
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
    }
}
