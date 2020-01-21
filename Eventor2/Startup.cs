using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eventor2.Startup))]
namespace Eventor2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
