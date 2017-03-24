using Moq;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Tests.TagsServiceTests
{
    [TestFixture]
    public class GetTagByName_Should
    {
        [Test]
        public void Return_All_Tags_By_Given_Name()
        {
            // Arrange
            var mockedTagsRepo = new Mock<IEfGenericRepository<Tag>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            var service = new TagsService(mockedTagsRepo.Object, mockedUOW.Object);

            var tag1 = new Tag() { TagName = "n1" };
            var expected = new Tag() { TagName = "n2" };
            var tag3 = new Tag() { TagName = "n3" };

            var tags = new List<Tag>()
            {
                tag1,
                expected,
                tag3
            };

            mockedTagsRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Tag, bool>>>()))
                    .Returns((Expression<Func<Tag, bool>> predicate) =>
                    tags.Where(predicate.Compile())
                    .FirstOrDefault());

            // Act
            var actual = service.GetTagByName("n2");

            // Assert
            Assert.AreSame(expected, actual);

        }
    }
}
