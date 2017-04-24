using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RPMS_Web.Startup))]
namespace RPMS_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
