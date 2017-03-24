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
    public class GetAllTags_Should
    {
        [Test]
        public void Return_All_Tags()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            var service = new TagsService(mockedTagsRepo.Object, mockedUOW.Object);

            var expected = new List<Tag>()
            {
                new Tag(),
                new Tag(),
                new Tag()
            };

            mockedTagsRepo.Setup(x => x.GetAll())
                    .Returns(expected);

            // Act
            var actual = service.GetAllTags();

            // Assert
            CollectionAssert.AreEquivalent(actual, expected);
        }
    }
}
