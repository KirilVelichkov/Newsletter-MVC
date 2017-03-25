using Moq;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.ViewModels.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.CategoryControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Return_Default_View()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();

            var controller = new CategoryController(mockedCategoryService.Object);

            // Act Assert
            controller.WithCallTo(c => c.Index(It.IsAny<string>(), 1, 5))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Return_View_With_Correct_Model()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();

            var controller = new CategoryController(mockedCategoryService.Object);

            var categories = new List<ListArticleByCategoryViewModel>()
            {
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel()
            };

            mockedCategoryService.Setup(x => x.GetArticleByCategory(It.IsAny<string>()))
                                 .Returns(categories);

            // Act
            var result = controller.Index(It.IsAny<string>(), 1, 5) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ArticleAndCategoryViewModel>(result.ViewData.Model);
        }

        [Test]
        public void Call_categoryService_GetArticleByCategory_Method_Once()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();

            var controller = new CategoryController(mockedCategoryService.Object);

            var categories = new List<ListArticleByCategoryViewModel>()
            {
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel(),
                new ListArticleByCategoryViewModel()
            };

            mockedCategoryService.Setup(x => x.GetArticleByCategory(It.IsAny<string>()))
                                 .Returns(categories);

            // Act
            controller.Index(It.IsAny<string>(), 1, 5);

            // Assert
            mockedCategoryService.Verify(x => x.GetArticleByCategory(It.IsAny<string>()), Times.Once);
        }
    }
}
