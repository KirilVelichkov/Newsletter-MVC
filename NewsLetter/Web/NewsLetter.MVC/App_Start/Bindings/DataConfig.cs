using NewsLetter.Data;
using NewsLetter.Data.Contracts;
using NewsLetter.Data.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsLetter.MVC.App_Start.Bindings
{

    public class DataConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<NewsLetterDBContext>().InRequestScope();
            this.Bind(typeof(IEfGenericRepository<>)).To(typeof(EfGenericRepository<>)).InRequestScope();
            //this.Bind(typeof(IProjectableRepositoryEf<>)).To(typeof(ProjectableRepositoryEf<>)).InRequestScope();
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<UnitOfWork>()).InRequestScope();
        }
    }
}