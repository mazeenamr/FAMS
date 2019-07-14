using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OGtech.Startup))]
namespace OGtech
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
