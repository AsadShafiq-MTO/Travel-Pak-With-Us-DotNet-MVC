using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Travel_Pakistan_With_Us.Startup))]
namespace Travel_Pakistan_With_Us
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
