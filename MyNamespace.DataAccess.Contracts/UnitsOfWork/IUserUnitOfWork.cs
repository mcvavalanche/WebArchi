using MyNamespace.DataAccess.Contracts.Repositories;

namespace MyNamespace.DataAccess.Contracts.UnitsOfWork
{
    public interface IUserUnitOfWork:IBaseUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        IUserDetailsRepository UserDetailsRepository { get; }

    }
}
