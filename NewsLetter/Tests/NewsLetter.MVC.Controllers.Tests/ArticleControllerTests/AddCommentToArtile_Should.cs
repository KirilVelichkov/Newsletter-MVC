using Moq;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.ViewModels.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.ArticleControllerTests
{
    [TestFixture]
    public class AddCommentToArtile_Should
    {

        [Test]
        public void Return_Correct_Partial_View_Get()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            // Act Assert
            controller.WithCallTo(x => x.AddCommentToArtile())
                    .ShouldRenderPartialView("_PostCommentPartial");
        }

        [Test]
        public void Have_HttpPost_Attribute_Post()
        {
            // Arrange
            var method = typeof(ArticleController)
                .GetMethod("AddCommentToArtile", new Type[] { typeof(int), typeof(CommentViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_Authorize_Attribute_Post()
        {
            // Arrange
            var method = typeof(ArticleController)
                .GetMethod("AddCommentToArtile", new Type[] { typeof(int), typeof(CommentViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(AuthorizeAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Call_mappingProvider_Map_Method_Once_Post()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            var comment = new Comment();
            var commentViewModel = new CommentViewModel();

            var controllerContext = new Mock<ControllerContext>();
            var principal = new Mock<IPrincipal>();

            principal.SetupGet(x => x.Identity.Name).Returns(It.IsAny<string>());
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            controller.ControllerContext = controllerContext.Object;

            mockedMappingProvider.Setup(x => x.Map<CommentViewModel, Comment>(commentViewModel))
                                 .Returns(comment);
           
            // Act 
            controller.AddCommentToArtile(1, commentViewModel);

            // Assert
            mockedMappingProvider.Verify(x => x.Map<CommentViewModel, Comment>(It.IsAny<CommentViewModel>()), Times.Once);
        }

        [Test]
        public void Call_articleService_AddCommentToArticle_Method_Once_Post()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            var comment = new Comment();
            var commentViewModel = new CommentViewModel();

            var controllerContext = new Mock<ControllerContext>();
            var principal = new Mock<IPrincipal>();

            principal.SetupGet(x => x.Identity.Name).Returns(It.IsAny<string>());
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            controller.ControllerContext = controllerContext.Object;

            mockedMappingProvider.Setup(x => x.Map<CommentViewModel, Comment>(commentViewModel))
                                 .Returns(comment);

            // Act 
            controller.AddCommentToArtile(1, commentViewModel);

            // Assert
            mockedArticleService.Verify(x => x.AddCommentToArticle(comment), Times.Once);
        }

        [Test]
        public void Return_Correct_Partial_View_Post()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            var comment = new Comment();
            var commentViewModel = new CommentViewModel();

            var controllerContext = new Mock<ControllerContext>();
            var principal = new Mock<IPrincipal>();

            principal.SetupGet(x => x.Identity.Name).Returns(It.IsAny<string>());
            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            controller.ControllerContext = controllerContext.Object;

            mockedMappingProvider.Setup(x => x.Map<CommentViewModel, Comment>(commentViewModel))
                                 .Returns(comment);

            // Act Assert
            controller.WithCallTo(x => x.AddCommentToArtile(It.IsAny<int>(), commentViewModel))
                   .ShouldRenderPartialView("_CommentsPartial");
        }
    }
}
