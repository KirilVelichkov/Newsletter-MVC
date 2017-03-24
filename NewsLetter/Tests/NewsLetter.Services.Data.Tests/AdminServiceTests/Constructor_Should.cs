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
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_articleRepository_IsNull()
        {
            // Arrange 
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminService(null, mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleRepository"));
        }

        [Test]
        public void Throw_When_unitOfWork_IsNull()
        {
            // Arrange 
            var mockedArticleRepo = new Mock<IEfGenericRepository<Article>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new AdminService(mockedArticleRepo.Object, null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
