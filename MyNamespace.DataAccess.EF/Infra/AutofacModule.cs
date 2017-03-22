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
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterType<Entities>().AsSelf();
            builder.Register(c => new Entities("name=Entities"));

            string[] namespaces = new[]
            {
                "MyNamespace.DataAccess.EF.Repositories",
                "MyNamespace.DataAccess.EF.UnitsOfWork"
            };

            builder.Register(c =>
                {
                    var ctx = c.Resolve<Entities>();
                    return new AuthUnitOfWork(ctx, c.Resolve<IUserRepository>(new TypedParameter(typeof(Entities), ctx)), c.Resolve<IRolesRepository>(new TypedParameter(typeof(Entities), ctx)));
                }
            );

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => namespaces.Contains(x.Namespace))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
        }
    }
}
