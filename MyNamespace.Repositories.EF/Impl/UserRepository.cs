using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.Model;
using MyNamespace.Repositories.Contracts;

namespace MyNamespace.Repositories.EF.Impl
{
    class UserRepository: GenericRepository<AspNetUsers>, IUserRepository
    {
        public UserRepository(Entities dbContext) : base(dbContext)
        {
        }
    }
}
