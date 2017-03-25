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
    public class Index_Should
    {
        [Test]
        public void Return_Default_View()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object, 
                mockedMappingProvider.Object);

            // Act Assert
            controller.WithCallTo(c => c.Index(It.IsAny<int>())).ShouldRenderDefaultView();
        }

        [Test]
        public void Return_View_With_Correct_Model()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new ArticleController(
                mockedArticleService.Object,
                mockedMappingProvider.Object);

            var articleViewModel = new SingleArticleViewModel();
            mockedArticleService.Setup(x => x.GetArticleById(It.IsAny<int>()))
                    .Returns(articleViewModel);

            // Act Assert
            controller.WithCallTo(c => c.Index(It.IsAny<int>())).ShouldRenderDefaultView()
                    .WithModel(articleViewModel);
                    
        }
    }
}
