using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHabbits.Startup))]
namespace MyHabbits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
