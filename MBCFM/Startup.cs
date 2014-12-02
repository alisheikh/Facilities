using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MBCFM.Startup))]
namespace MBCFM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
