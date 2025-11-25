using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CasoPractico1_JorgeMorua.Identity.Startup))]
namespace CasoPractico1_JorgeMorua.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
