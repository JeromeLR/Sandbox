using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvctest.Startup))]
namespace mvctest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
