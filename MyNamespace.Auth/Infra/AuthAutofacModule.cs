using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyNamespace.Web.Auth.Interfaces;

namespace MyNamespace.Web.Auth.Infra
{
    public class AuthAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder
                .RegisterType<EmailService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder
                .Register(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>())
                .OnActivated(e => (e.Instance).EmailService = e.Context.Resolve<IIdentityMessageService>())
                .As<IUserManager>();


            builder.Register(c => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()).As<ISignInManager>();

        }
    }
}
