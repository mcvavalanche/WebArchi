using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    internal class UserDetailsRepository:GenericRepository<UserDetails>,IUserDetailsRepository
    {
        public UserDetailsRepository(Entities dbContext) : base(dbContext)
        {
        }
    }
}
