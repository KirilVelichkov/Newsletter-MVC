using Bytes2you.Validation;
using NewsLetter.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            Guard.WhenArgument(articleService, nameof(articleService)).IsNull().Throw();

            this.articleService = articleService;
        }

        public ActionResult Index(int id)
        {
            var model = this.articleService.GetArticleById(id);

            return View(model);
        }
    }
}