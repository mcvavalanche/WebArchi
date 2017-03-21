using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace MyNamespace.WebApi.Infra
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

        }
    }
}