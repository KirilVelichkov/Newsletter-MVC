using Moq;
using NewsLetter.Models.DbModels;
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

namespace NewsLetter.MVC.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void Return_Default_View()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new AdminController(
                mockedAdminService.Object,
                mockedArticleService.Object,
                mockedCategoryService.Object,
                mockedTagsService.Object,
                mockedMappingProvider.Object
                );

            // Act Assert
            controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void Retrun_View_With_Correct_Model()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new AdminController(
                mockedAdminService.Object,
                mockedArticleService.Object,
                mockedCategoryService.Object,
                mockedTagsService.Object,
                mockedMappingProvider.Object
                );

            mockedCategoryService.Setup(x => x.GetAllCategories()).Returns(It.IsAny<IEnumerable<CategoryViewModel>>());

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOf<CreateArticleViewModel>(result.ViewData.Model);
        }

        [Test]
        public void Call_categoryService_GetAllCategories_Method_Once()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            var controller = new AdminController(
                mockedAdminService.Object,
                mockedArticleService.Object,
                mockedCategoryService.Object,
                mockedTagsService.Object,
                mockedMappingProvider.Object
                );

            mockedCategoryService.Setup(x => x.GetAllCategories()).Returns(It.IsAny<IEnumerable<CategoryViewModel>>());

            // Act
            var result = controller.Index();

            // Assert
            mockedCategoryService.Verify(x => x.GetAllCategories(), Times.Once);
        }
    }
}
