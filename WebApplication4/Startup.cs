using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication4.Web.Startup))]
namespace WebApplication4.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
