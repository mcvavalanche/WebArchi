using Autofac;

namespace MyNamespace.Core.Infra
{
    public class CoreAutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Namespace == "MyNamespace.Core.Services")
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
        }
    }
}
