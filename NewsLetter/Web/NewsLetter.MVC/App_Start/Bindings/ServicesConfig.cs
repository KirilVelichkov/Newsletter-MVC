using AutoMapper;
using Microsoft.Owin;
using NewsLetter.Auth.Identity.Contracts;
using NewsLetter.Auth.Identity.Services;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Data.Services;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.Services.Providers.Providers;
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

            this.Bind<IMapper>()
                .ToMethod(c => MappingProfile.InitializeAutoMapper().CreateMapper());

            this.Bind<IMappingProvider>().To<MappingProvider>().InRequestScope();
            this.Bind<IAdminService>().To<AdminService>().InRequestScope();
            this.Bind<IArticleService>().To<ArticleService>().InRequestScope();
            this.Bind<ITagsService>().To<TagsService>().InRequestScope();
            this.Bind<ICategoryService>().To<CategoryService>().InRequestScope();
        }
    }
}