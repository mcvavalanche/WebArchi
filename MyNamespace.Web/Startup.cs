using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyNamespace.Web.Startup))]
namespace MyNamespace.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
