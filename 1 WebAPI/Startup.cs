using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1_WebAPI.Startup))]
namespace _1_WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
