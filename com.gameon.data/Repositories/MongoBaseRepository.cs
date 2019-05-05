using com.gameon.data.Interfaces;
using com.gameon.data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.gameon.data.Repositories
{
    public class MongoBaseRepository<T> : IDocumentRepository<T> where T : DocumentBase
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

        public T Get(string id)
        {
            return _collection.Find(doc => doc.Id == id).FirstOrDefault();
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
        
        public async void Replace(string id, T doc)
        {
            // ReplaceOne = replace the whole document
            // UpdateOne = Update certain fields of a document. old fields that aren't changed remain in document
            await _collection.ReplaceOneAsync(d => d.Id == id, doc);
        }

        public async void Delete(T doc)
        {
            await _collection.DeleteOneAsync(d => d.Id == doc.Id);
        }

        public async void Delete(string id)
        {
            await _collection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
