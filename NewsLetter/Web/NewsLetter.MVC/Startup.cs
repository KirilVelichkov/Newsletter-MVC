using Microsoft.Owin;
using NewsLetter.Auth.Identity;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsLetter.MVC.Startup))]
namespace NewsLetter.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var identityConfig = new IdentityConfig();
            identityConfig.ConfigureAuth(app);
        }
    }
}
