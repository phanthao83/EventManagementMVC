using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsManagementWeb.Startup))]
namespace EventsManagementWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
