using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanChi.FMS.App.Startup))]
namespace VanChi.FMS.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
