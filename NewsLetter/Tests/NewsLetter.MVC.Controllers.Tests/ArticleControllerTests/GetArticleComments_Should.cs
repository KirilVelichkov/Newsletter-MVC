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
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.ArticleControllerTests
{
    [TestFixture]
    public class GetArticleComments_Should
    {
        [Test]
        public void Return_Correct_Partial_View()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            // Act Assert
            controller.WithCallTo(x => x.GetArticleComments(It.IsAny<int>()))
                    .ShouldRenderPartialView("_CommentsPartial");
        }

        [Test]
        public void Return_Correct_Partial_View_With_Correct_Model()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            var model = new List<CommentViewModel>();

            mockedArticleService.Setup(x => x.GetArticleComments(It.IsAny<int>()))
                    .Returns(model);

            // Act Assert
            controller.WithCallTo(x => x.GetArticleComments(It.IsAny<int>()))
                    .ShouldRenderPartialView("_CommentsPartial")
                    .WithModel(model);
        }

        [Test]
        public void Call_articleService_GetArticleComments_Method_Once()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            mockedArticleService.Setup(x => x.GetArticleComments(It.IsAny<int>()))
                    .Returns(It.IsAny<IEnumerable<CommentViewModel>>());

            // Act 
            controller.GetArticleComments(It.IsAny<int>());

            // Assert
            mockedArticleService.Verify(x => x.GetArticleComments(It.IsAny<int>()), Times.Once);
        }   
    }
}
