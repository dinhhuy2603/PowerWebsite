using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PowerWebsite.Startup))]
namespace PowerWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
