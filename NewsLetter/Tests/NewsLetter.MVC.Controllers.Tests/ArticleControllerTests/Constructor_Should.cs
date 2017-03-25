using Moq;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.MVC.Controllers.Tests.ArticleControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_articleService_IsNull()
        {
            // Arrange
            //var mockedArticleService = new Mock<IArticleService>();
            var mockedMappingProvider = new Mock<IMappingProvider>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleController(
                    null,
                    mockedMappingProvider.Object
                    );
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleService"));
        }

        [Test]
        public void Throw_When_mappingProvider_IsNull()
        {
            // Arrange
            var mockedArticleService = new Mock<IArticleService>();
            //var mockedMappingProvider = new Mock<IMappingProvider>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleController(
                    mockedArticleService.Object,
                    null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("mappingProvider"));
        }
    }
}
