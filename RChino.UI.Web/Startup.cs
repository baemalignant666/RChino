using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RChino.UI.Web.Startup))]
namespace RChino.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
