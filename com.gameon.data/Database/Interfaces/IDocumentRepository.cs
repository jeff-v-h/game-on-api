using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace com.gameon.data.Database.Interfaces
{
    public interface IDocumentRepository<T>
    {
        IFindFluent<T, T> GetAllBy(Expression<Func<T, bool>> predicate);
        IFindFluent<T, T> GetBy(Expression<Func<T, bool>> predicate);
        T Get(string id);
        T Create(T doc);
        void Replace(string id, T doc);
        void Delete(T doc);
        void Delete(string id);
    }
}
