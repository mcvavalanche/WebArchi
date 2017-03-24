using System.Linq;
using System.Runtime.CompilerServices;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    class UserRepository: GenericRepository<AspNetUsers>, IUserRepository
    {
        public UserRepository(Entities dbContext) : base(dbContext)
        {
        }

        public override bool IsNew(AspNetUsers obj)
        {
            return !DbContext.Set<AspNetUsers>().Any(u => u.Id == obj.Id);
            //return string.IsNullOrEmpty(obj.Id);
        }
    }
}
