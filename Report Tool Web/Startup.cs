using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Report_Tool_Web.Startup))]
namespace Report_Tool_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
