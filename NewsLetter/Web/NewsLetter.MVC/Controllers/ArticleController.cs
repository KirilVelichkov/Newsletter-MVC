using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using NewsLetter.Models.DbModels;
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
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMappingProvider mappingProvider;

        public ArticleController(IArticleService articleService, IMappingProvider mappingProvider)
        {
            Guard.WhenArgument(articleService, nameof(articleService)).IsNull().Throw();
            Guard.WhenArgument(mappingProvider, nameof(mappingProvider)).IsNull().Throw();

            this.articleService = articleService;
            this.mappingProvider = mappingProvider;
        }

        public ActionResult Index(int id)
        {
            var model = this.articleService.GetArticleById(id);

            return View(model);
        }

        public ActionResult GetArticleComments(int id)
        {
            var model = this.articleService.GetArticleComments(id);

            return this.PartialView("_CommentsPartial", model);
        }

        public ActionResult AddCommentToArtile()
        {
            return this.PartialView("_PostCommentPartial");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddCommentToArtile(int articleId, CommentViewModel comment)
        {
            var commentToAdd = this.mappingProvider.Map<CommentViewModel, Comment>(comment);
            commentToAdd.ArticleId = articleId;
            commentToAdd.UserId = this.User.Identity.GetUserId();

            this.articleService.AddCommentToArticle(commentToAdd);

            return this.GetArticleComments(articleId);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddCommentReply(int articleId, int commentId, CommentReplyViewModel comment)
        {
            var commentToAdd = this.mappingProvider.Map<CommentReplyViewModel, CommentReply>(comment);
            commentToAdd.CommentId = commentId;
            commentToAdd.UserId = this.User.Identity.GetUserId();

            this.articleService.AddCommentReply(commentToAdd);

            return this.GetArticleComments(articleId);
        }
    }
}