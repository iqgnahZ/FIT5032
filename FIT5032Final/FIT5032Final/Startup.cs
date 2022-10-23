using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032Final.Startup))]
namespace FIT5032Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
