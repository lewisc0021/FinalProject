using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarketStumblerFinal.Startup))]
namespace MarketStumblerFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
