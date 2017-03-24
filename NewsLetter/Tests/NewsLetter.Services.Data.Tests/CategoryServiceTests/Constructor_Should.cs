using Moq;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Tests.CategoryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_articleRepository_IsNull()
        {
            // Arrange
            var mockedCategoryRepo = new Mock<IEfMappingRepository<Category>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new CategoryService(
                    null, 
                    mockedCategoryRepo.Object,
                    mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleRepository"));
        }

        [Test]
        public void Throw_When_categoryRepository_IsNull()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new CategoryService(
                    mockedArticleRepo.Object,
                    null,
                    mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("categoryRepository"));
        }

        [Test]
        public void Throw_When_unitOfWork_IsNull()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCategoryRepo = new Mock<IEfMappingRepository<Category>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new CategoryService(
                    mockedArticleRepo.Object,
                    mockedCategoryRepo.Object,
                    null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
