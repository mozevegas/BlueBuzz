using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBuzz.Startup))]
namespace BlueBuzz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
