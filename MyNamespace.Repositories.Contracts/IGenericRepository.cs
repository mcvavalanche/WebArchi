using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        void Delete(T obj);
        void Add(T obj);
    }
}
