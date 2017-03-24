using Bytes2you.Validation;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();

            this.categoryService = categoryService;
        }

        public ActionResult Index(string category, int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;
            var Take = pageSize;

            var articlesByCategory = this.categoryService.GetArticleByCategory(category);
            var articlesCount = articlesByCategory.Count() / pageSize;
            var pagedArticles = articlesByCategory.Skip(skip).Take(Take);

            if (articlesCount < 1)
            {
                articlesCount = 1;
            }

            var ArticlesByCategoryViewModel = new ArticleAndCategoryViewModel()
            {
                ArticlesByCategory = pagedArticles,
                CategoryName = category,
                ArticlesCount = articlesCount,
                pageNumber = pageNumber,
                pageSize = pageSize
            };

            return View(ArticlesByCategoryViewModel);
        }
    }
}