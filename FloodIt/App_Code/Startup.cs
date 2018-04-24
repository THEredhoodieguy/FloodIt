using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FloodIt.Startup))]
namespace FloodIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
