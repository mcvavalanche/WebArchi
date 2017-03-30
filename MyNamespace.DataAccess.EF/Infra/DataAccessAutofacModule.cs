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
            builder.Register(c => new Entities(_connectionString)).InstancePerLifetimeScope();

            //register repositories
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Namespace == "MyNamespace.DataAccess.EF.Repositories")
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

            builder.RegisterType<BaseUnitOfWork>().As<IBaseUnitOfWork>();

            //builder.Register(c =>
            //        {
            //            var ctx = c.Resolve<Entities>();
            //            var paramCtx = new TypedParameter(typeof(Entities), ctx);
            //            return new UserUnitOfWork(ctx,
            //                c.Resolve<IUserRepository>(paramCtx),
            //                c.Resolve<IUserDetailsRepository>(paramCtx),
            //                c.Resolve<IRolesRepository>(paramCtx));
            //        }
            //    ).As<IUserUnitOfWork>();

        }
    }
}
