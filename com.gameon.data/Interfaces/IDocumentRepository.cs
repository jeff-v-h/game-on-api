using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace com.gameon.data.Interfaces
{
    public interface IDocumentRepository<T>
    {
        IFindFluent<T, T> GetAll();
        IFindFluent<T, T> GetBy(Expression<Func<T, bool>> predicate);
        T Create(T doc);
        void Replace(string id, T doc);
        void Delete(T doc);
        void Delete(string id);
    }
}
