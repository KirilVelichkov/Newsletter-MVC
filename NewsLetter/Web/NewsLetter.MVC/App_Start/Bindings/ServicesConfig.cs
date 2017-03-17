using Microsoft.Owin;
using NewsLetter.Auth.Identity.Contracts;
using NewsLetter.Auth.Identity.Services;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Data.Services;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetter.MVC.App_Start.Bindings
{
    public class ServicesConfig : NinjectModule
    {
        public override void Load() 
        {
            this.Bind<IAuthService>().To<AuthService>();
            this.Bind<IOwinContext>()
               .ToMethod(c => HttpContext.Current.GetOwinContext())
               .WhenInjectedInto(typeof(IAuthService))
               .InRequestScope();

            this.Bind<IAdminService>().To<AdminService>().InRequestScope();
        }
    }
}