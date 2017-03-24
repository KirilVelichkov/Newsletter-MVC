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

namespace NewsLetter.Services.Data.Tests.TagsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_tagsRepository_IsNull()
        {
            // Arrange
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new TagsService(
                    null,
                    mockedUOW.Object);
            });

            // Assert
            Assert.That(ex.ParamName, Is.EqualTo("tagsRepository"));
        }

        [Test]
        public void Throw_When_unitOfWork_IsNull()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new TagsService(
                    mockedTagsRepo.Object,
                    null);
            });

            // Assert
            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
