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
    public class GetArticleComments_Should
    {
        [Test]
        public void Return_All_For_The_Article_By_Given_Id()
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

            var commentsList = new List<Comment>()
            {
                new Comment() {ArticleId = 1 },
                new Comment() {ArticleId = 1 },
                new Comment() {ArticleId = 1 },
                new Comment() {ArticleId = 2 },
                new Comment() {ArticleId = 2 },
                new Comment() {ArticleId = 3 },
                new Comment() {ArticleId = 4 },
            };

            var expected = 3;

            mockedCommentsRepo.Setup(
                x => x.GetAllMapped<CommentViewModel>(It.IsAny<Expression<Func<Comment, bool>>>()))
                .Returns((Expression<Func<Comment, bool>> predicate) =>
                commentsList.Where(predicate.Compile()).Select(x => new CommentViewModel()));
           
            // Act
            var actual = service.GetArticleComments(1);

            // Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}
