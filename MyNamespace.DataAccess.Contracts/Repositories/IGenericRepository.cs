using System.Collections.Generic;

namespace MyNamespace.DataAccess.Contracts.Repositories
{
    public interface IGenericRepository<T>
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        void Delete(T obj);
        void Add(T obj);
    }
}
