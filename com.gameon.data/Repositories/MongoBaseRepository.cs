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

        public T Create(T doc)
        {
            try
            {
                _collection.InsertOne(doc);
                return doc;
            }
            catch (MongoCommandException ex)
            {
                throw new Exception($"Error while creating document: {ex}");
            }
        }
        
        public void Replace(string id, T doc)
        {
            try
            {
                // ReplaceOne = replace the whole document
                // UpdateOne = Update certain fields of a document. old fields that aren't changed remain in document
                _collection.ReplaceOne(d => d.Id == id, doc);
            }
            catch (MongoCommandException ex)
            {
                throw new Exception($"Error with updating document: {ex}");
            }
            
        }

        public void Delete(T doc)
        {
            _collection.DeleteOne(d => d.Id == doc.Id);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(d => d.Id == id);
        }
    }
}
