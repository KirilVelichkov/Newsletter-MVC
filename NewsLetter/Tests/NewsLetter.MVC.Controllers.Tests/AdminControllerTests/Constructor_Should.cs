using Moq;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.MVC.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_adminService_IsNull()
        {
            // Arrange
            //var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();


            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminController(
                    null,
                    mockedArticleService.Object,
                    mockedCategoryService.Object,
                    mockedTagsService.Object,
                    mockedMappingProvider.Object
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("adminService"));
        }

        [Test]
        public void Throw_When_articleService_IsNull()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            //var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();


            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminController(
                    mockedAdminService.Object,
                    null,
                    mockedCategoryService.Object,
                    mockedTagsService.Object,
                    mockedMappingProvider.Object
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleService"));
        }

        [Test]
        public void Throw_When_categoryService_IsNull()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            //var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();


            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminController(
                    mockedAdminService.Object,
                    mockedArticleService.Object,
                    null,
                    mockedTagsService.Object,
                    mockedMappingProvider.Object
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("categoryService"));
        }

        [Test]
        public void Throw_When_tagsService_IsNull()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            //var mockedTagsService = new Mock<ITagsService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminController(
                    mockedAdminService.Object,
                    mockedArticleService.Object,
                    mockedCategoryService.Object,
                    null,
                    mockedMappingProvider.Object
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("tagsService"));
        }

        [Test]
        public void Throw_When_mappingProvider_IsNull()
        {
            // Arrange
            var mockedAdminService = new Mock<IAdminService>();
            var mockedArticleService = new Mock<IArticleService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedTagsService = new Mock<ITagsService>();
            //var mockedMappingProvider = new Mock<IMappingProvider>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminController(
                    mockedAdminService.Object,
                    mockedArticleService.Object,
                    mockedCategoryService.Object,
                    mockedTagsService.Object,
                    null
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("mappingProvider"));
        }
    }
}
