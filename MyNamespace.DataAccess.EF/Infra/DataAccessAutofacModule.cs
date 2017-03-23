using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Contracts.UnitsOfWork;
using MyNamespace.DataAccess.EF.UnitsOfWork;

namespace MyNamespace.DataAccess.EF.Infra
{
    public class DataAccessAutofacModule : Module
    {
        private readonly string _connectionString;

        public DataAccessAutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterType<Entities>().AsSelf();
            builder.Register(c => new Entities(_connectionString));

            //register repositories
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Namespace == "MyNamespace.DataAccess.EF.Repositories")
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

            //register UnitOfWork
            builder.Register(c =>
                    {
                        var ctx = c.Resolve<Entities>();
                        return new AuthUnitOfWork(ctx,
                            c.Resolve<IUserRepository>(new TypedParameter(typeof(Entities), ctx)),
                            c.Resolve<IRolesRepository>(new TypedParameter(typeof(Entities), ctx)));
                    }
                ).As<IAuthUnitOfWork>();

        }
    }
}
