using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(To_Gather.WebMVC.Startup))]
namespace To_Gather.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
