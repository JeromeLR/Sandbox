using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1_AspMvc.Startup))]
namespace _1_AspMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
