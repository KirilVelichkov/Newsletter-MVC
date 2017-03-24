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

namespace NewsLetter.Services.Data.Tests.AdminServiceTests
{
    [TestFixture]
    public class CreateArticle_Should
    {

        [Test]
        public void Throw_When_Article_IsNull()
        {
            // Arrange 
            var mockedArticleRepo = new Mock<IEfGenericRepository<Article>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();
            var service = new AdminService(mockedArticleRepo.Object, mockedUOW.Object);

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                service.CreateArticle(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("article"));
        }

        [Test]
        public void Call_articleRepository_Add_Method_Once()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfGenericRepository<Article>>();
            var mockedUOW = new Mock<IUnitOfWork>();
            var service = new AdminService(mockedArticleRepo.Object, () => mockedUOW.Object);

            var articleToAdd = new Article();

            mockedArticleRepo.Setup(x => x.Add(It.IsAny<Article>()));

            // Act
            service.CreateArticle(articleToAdd);

            // Assert
            mockedArticleRepo.Verify(x => x.Add(It.IsAny<Article>()), Times.Once);
        }

        [Test]
        public void Call_unitOfWork_Commit_Method_Once()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfGenericRepository<Article>>();
            var mockedUOW = new Mock<IUnitOfWork>();
            var service = new AdminService(mockedArticleRepo.Object, () => mockedUOW.Object);

            var articleToAdd = new Article();

            mockedArticleRepo.Setup(x => x.Add(It.IsAny<Article>()));

            // Act
            service.CreateArticle(articleToAdd);

            // Assert
            mockedUOW.Verify(x => x.Commit(), Times.Once);
        }
    }
}
