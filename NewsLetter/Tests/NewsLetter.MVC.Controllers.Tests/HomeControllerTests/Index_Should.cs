using Moq;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.ViewModels.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        public void Return_Default_View()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();

            var controller = new HomeController(mockedArticleService.Object);

            // Act Assert
            controller.WithCallTo(c => c.Index(1, 5))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Return_View_With_Correct_Model()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();

            var controller = new HomeController(mockedArticleService.Object);

            var categories = new List<ListArticleByCategoryViewModel>()
            {
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel()
            };

            mockedArticleService.Setup(x => x.GetAllArticles())
                                 .Returns(categories);

            // Act
            var result = controller.Index(1, 5) as ViewResult;

            // Assert
            Assert.IsInstanceOf<HomeArticlesViewModel>(result.ViewData.Model);
        }

        [Test]
        public void Call_articleService_GetAllArticles_Method_Once()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();

            var controller = new HomeController(mockedArticleService.Object);

            var categories = new List<ListArticleByCategoryViewModel>()
            {
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel()
            };

            mockedArticleService.Setup(x => x.GetAllArticles())
                                 .Returns(categories);

            // Act
            controller.Index(1, 5);

            // Assert
            mockedArticleService.Verify(x => x.GetAllArticles(), Times.Once);
        }
    }
}
