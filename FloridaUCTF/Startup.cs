using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FloridaUCTF.Startup))]
namespace FloridaUCTF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
