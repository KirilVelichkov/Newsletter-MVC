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
    public class CreateTag_Should
    {
        [Test]
        public void Throw_When_The_Given_Tag_IsNull()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new TagsService(mockedTagsRepo.Object, () => mockedUOW.Object);

            mockedTagsRepo.Setup(x => x.Add(It.IsAny<Tag>()));

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                service.CreateTag(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("tagName"));
        }

        [Test]
        public void Throw_When_The_Given_Tag_IsEmpty()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new TagsService(mockedTagsRepo.Object, () => mockedUOW.Object);

            mockedTagsRepo.Setup(x => x.Add(It.IsAny<Tag>()));

            // Act Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                service.CreateTag(string.Empty);
            });

            Assert.That(ex.ParamName, Is.EqualTo("tagName"));
        }

        [Test]
        public void Call_tagsRepository_Add_Method_Once()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new TagsService(mockedTagsRepo.Object, () => mockedUOW.Object);

            var tagToAdd = "tag name";

            mockedTagsRepo.Setup(x => x.Add(It.IsAny<Tag>()));

            // Act 
            service.CreateTag(tagToAdd);

            // Assert
            mockedTagsRepo.Verify(x => x.Add(It.IsAny<Tag>()), Times.Once);
        }

        [Test]
        public void Call_unitOfWork_Commit_Method_Once()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new TagsService(mockedTagsRepo.Object, () => mockedUOW.Object);

            var tagToAdd = "tag name";

            mockedTagsRepo.Setup(x => x.Add(It.IsAny<Tag>()));

            // Act 
            service.CreateTag(tagToAdd);

            // Assert
            mockedUOW.Verify(x => x.Commit(), Times.Once);
        }
    }
}
