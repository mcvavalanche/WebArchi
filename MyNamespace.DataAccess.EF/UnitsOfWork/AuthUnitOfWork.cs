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
    /// <summary>
    /// Example of grouping 2 repos in one UOW.
    /// </summary>
    public class AuthUnitOfWork:BaseUnitOfWork, IAuthUnitOfWork
    {
        //public AuthUnitOfWork(Entities context):base(context)
        //{
        //    UserRepository = new UserRepository(DbContext);
        //    RolesRepository = new RolesRepository(DbContext);
        //}

        public AuthUnitOfWork(Entities context,IUserRepository ur, IRolesRepository rr):base(context)
        {
            UserRepository = ur;
            RolesRepository = rr;
        }

        public IUserRepository UserRepository { get; }
        public IRolesRepository RolesRepository { get; }
    }
}
