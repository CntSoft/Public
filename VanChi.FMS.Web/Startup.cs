using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanChi.FMS.Web.Startup))]
namespace VanChi.FMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
