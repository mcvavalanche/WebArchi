using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace MyNamespace.WebApi
{
    public class AppContext
    {
        private IContainer _container;
        public void SetIocContainer(IContainer container)
        {
            _container = container;
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}