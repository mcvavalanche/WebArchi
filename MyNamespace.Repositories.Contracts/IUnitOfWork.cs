using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}
