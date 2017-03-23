using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNet.Identity;

namespace MyNamespace.Web.Auth.Infra
{
    class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

    //        builder
    //.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>())
    //.OnActivated(e => (e.Instance).EmailService = e.Context.Resolve<IIdentityMessageService>())
    //.As<IUserManager>();

    //        builder
    //            .Register(c => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>())
    //            .As<ISignInManager>();

        }
    }
}
