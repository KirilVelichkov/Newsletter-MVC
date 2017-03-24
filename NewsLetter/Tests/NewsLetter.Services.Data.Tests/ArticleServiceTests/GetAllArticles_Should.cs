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
    public class GetAllArticles_Should
    {
        [Test]
        public void Return_All_Articles()
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

            var articl1 = new ListArticleByCategoryViewModel();
            var articl2 = new ListArticleByCategoryViewModel();
            var articl3 = new ListArticleByCategoryViewModel();

            var articles = new List<ListArticleByCategoryViewModel>()
            {
                articl1,
                articl2,
                articl3
            };

            var expected = 3;

            mockedArticleRepo.Setup(
                x => x.GetAllMapped<ListArticleByCategoryViewModel>())
                .Returns(articles);
           
            // Act
            var actual = service.GetAllArticles();

            // Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}
