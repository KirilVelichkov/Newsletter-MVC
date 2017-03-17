using Bytes2you.Validation;
using NewsLetter.MVC.ViewModels;
using NewsLetter.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            Guard.WhenArgument(adminService, nameof(adminService)).IsNull().Throw();

            this.adminService = adminService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateArticle()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateArticle(CreateArticleViewModel article)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return View(article);
        //    }



        //    this.adminService.CreateArticle(article);
        //}
    }
}