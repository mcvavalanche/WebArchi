using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Contracts.UnitsOfWork;
using MyNamespace.DataAccess.EF.Repositories;

namespace MyNamespace.DataAccess.EF.UnitsOfWork
{
    public class UserUnitOfWork : BaseUnitOfWork, IUserUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public IUserDetailsRepository UserDetailsRepository { get; }

        public UserUnitOfWork(Entities context,
                IUserRepository userRepo,
                IUserDetailsRepository userDetailsRepo,
                IRolesRepository roleRepo
            ) : base(context)
        {
            UserDetailsRepository = userDetailsRepo;
            UserRepository = userRepo;
            RolesRepository = roleRepo;
        }
    }
}
