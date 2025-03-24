using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JeffCrystalTest.Startup))]
namespace JeffCrystalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
