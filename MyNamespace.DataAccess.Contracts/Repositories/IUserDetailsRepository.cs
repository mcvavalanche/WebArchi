using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.Contracts.Repositories
{
    public interface IUserDetailsRepository:IGenericRepository<UserDetails>
    {
    }
}
