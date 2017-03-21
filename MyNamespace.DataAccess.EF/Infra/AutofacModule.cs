using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace MyNamespace.DataAccess.EF.Infra
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Entities>().AsSelf();

            string[] namespaces = new[]
            {
                "MyNamespace.DataAccess.EF.Repositories",
                "MyNamespace.DataAccess.EF.UnitsOfWork"
            };
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => namespaces.Contains(x.Namespace))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
        }
    }
}
