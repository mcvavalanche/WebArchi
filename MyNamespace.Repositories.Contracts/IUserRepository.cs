using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.Model;

namespace MyNamespace.Repositories.Contracts
{
    public interface IUserRepository:IGenericRepository<AspNetUsers>
    {
        
    }
}
