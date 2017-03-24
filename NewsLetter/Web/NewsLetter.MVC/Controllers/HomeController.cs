using Bytes2you.Validation;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            Guard.WhenArgument(articleService, nameof(articleService)).IsNull().Throw();

            this.articleService = articleService;
        }

        public ActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            var skip = (pageNumber - 1) * pageSize;
            var Take = pageSize;

            var allArticles = this.articleService.GetAllArticles();
            var articlesCount = allArticles.Count() / pageSize;
            var pagedArticles = allArticles.Skip(skip).Take(Take);

            if (articlesCount < 1)
            {
                articlesCount = 1;
            }

            var model = new HomeArticlesViewModel()
            {
                Articles = pagedArticles,
                ArticlesCount = articlesCount,
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            return View(model);
        }
    }
}