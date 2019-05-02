using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.gameon.data.Interfaces
{
    public interface IDocumentRepository<T>
    {
        IFindFluent<T, T> GetAll();
        IFindFluent<T, T> GetBy(Expression<Func<T, bool>> predicate);
        Task<T> Create(T doc);
    }
}
