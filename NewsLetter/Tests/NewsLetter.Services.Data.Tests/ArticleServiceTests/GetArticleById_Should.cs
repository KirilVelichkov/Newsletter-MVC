using Moq;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Services;
using NewsLetter.ViewModels.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Tests.ArticleServiceTests
{
    [TestFixture]
    public class GetArticleById_Should
    {
        [Test]
        public void Return_The_Correct_Article_ById()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            var service = new ArticleService(
                mockedArticleRepo.Object,
                mockedCommentsRepo.Object,
                mockedCommentsReplyRepo.Object,
                mockedUOW.Object
                );

            var articl1 = new Article() { Id = 1 };
            var expected = new Article() { Id = 2 };
            var articl3 = new Article() { Id = 3 };

            var articles = new List<Article>()
            {
                articl1,
                expected,
                articl3
            };
           
            mockedArticleRepo.Setup(
                x => x.GetFirstMapped<SingleArticleViewModel>(It.IsAny<Expression<Func<Article, bool>>>()))
                    .Returns((Expression<Func<Article, bool>> predicate) =>
                       articles.Where(predicate.Compile())
                       .Select(x => new SingleArticleViewModel() { Id = x.Id })
                       .FirstOrDefault());
            // Act
            var actual = service.GetArticleById(2);

            // Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}
