using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppProducts.Startup))]
namespace WebAppProducts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
