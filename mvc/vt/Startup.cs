using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vt.Startup))]
namespace vt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
