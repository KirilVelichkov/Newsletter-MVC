using Bytes2you.Validation;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace NewsLetter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly ITagsService tagsService;
        private readonly IMappingProvider mappingProvider;

        public AdminController(
                IAdminService adminService,
                ICategoryService categoryService,
                IArticleService articleService,
                ITagsService tagsService,
                IMappingProvider mappingProvider)
        {
            Guard.WhenArgument(adminService, nameof(adminService)).IsNull().Throw();
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();
            Guard.WhenArgument(tagsService, nameof(tagsService)).IsNull().Throw();
            Guard.WhenArgument(articleService, nameof(articleService)).IsNull().Throw();

            this.mappingProvider = mappingProvider;
            this.categoryService = categoryService;
            this.articleService = articleService;
            this.tagsService = tagsService;
            this.adminService = adminService;
        }

        public ActionResult Index()
        {
            var model = new CreateArticleViewModel();
            model.Categories = this.categoryService.GetAllCategories();

            return View(model);
        }

        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(CreateArticleViewModel article)
        {
            if (!this.ModelState.IsValid)
            {
                return View(article);
            }

            var articleTags = article.TagNames.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var allDbTags = this.tagsService.GetAllTags().Select(x => x.TagName);

            var fileExtension = Path.GetExtension(article.ArticleImage.FileName);
            var imageName = article.Title + fileExtension;
            var imagePath = Server.MapPath($"~/Images/Articles/{imageName}");

            var articleImageUrl = $"/Images/Articles/{imageName}";

            article.ArticleImage.SaveAs(imagePath);

            var uniqueTags = new HashSet<string>();
            var tagsForArticle = new List<Tag>();

            foreach (var tagName in articleTags)
            {
                if (!allDbTags.Contains(tagName.ToLower()))
                {
                    uniqueTags.Add(tagName);
                    this.tagsService.CreateTag(tagName);
                }
            }

            foreach (var tag in articleTags)
            {
                tagsForArticle.Add(this.tagsService.GetTagByName(tag));
            }

            var mappedArticle = this.mappingProvider.Map<CreateArticleViewModel, Article>(article);
            mappedArticle.ImageUrl = articleImageUrl;
            mappedArticle.Tags = tagsForArticle;

            this.adminService.CreateArticle(mappedArticle);
            return this.RedirectToAction("Index");
        }

    }
}