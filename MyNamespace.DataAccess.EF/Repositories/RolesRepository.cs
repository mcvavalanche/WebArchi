using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    class RolesRepository: GenericRepository<AspNetRoles>, IRolesRepository
    {
        public RolesRepository(Entities dbContext) : base(dbContext)
        {
        }

    }
}
