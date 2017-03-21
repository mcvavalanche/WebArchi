using MyNamespace.DataAccess.Contracts.Repositories;

namespace MyNamespace.DataAccess.Contracts.UnitsOfWork
{
    public interface IAuthUnitOfWork:IBaseUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
    }
}
