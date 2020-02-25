using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VanChi.FMS.Startup))]
namespace VanChi.FMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
