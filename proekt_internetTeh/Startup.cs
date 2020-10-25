using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proekt_internetTeh.Startup))]
namespace proekt_internetTeh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
