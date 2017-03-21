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

        public ActionResult Index(string category)
        {
            var articlesByCategory = this.categoryService.GetArticleByCategory(category);

            var ArticlesByCategoryViewModel = new ArticleAndCategoryViewModel()
            {
                ArticlesByCategory = articlesByCategory,
                CategoryName = category
            };

            return View(ArticlesByCategoryViewModel);
        }
    }
}