using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    class UserRepository: GenericRepository<AspNetUsers>, IUserRepository
    {
        public UserRepository(Entities dbContext) : base(dbContext)
        {
        }
    }
}
