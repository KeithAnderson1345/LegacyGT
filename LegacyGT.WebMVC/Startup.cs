using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LegacyGT.WebMVC.Startup))]
namespace LegacyGT.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
