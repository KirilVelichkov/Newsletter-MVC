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

namespace NewsLetter.Services.Data.Tests.ArticleServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_articleRepository_IsNull()
        {
            // Arrange 
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleService(
                    null,
                    mockedCommentsRepo.Object,
                    mockedCommentsReplyRepo.Object,
                    mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("articleRepository"));
        }

        [Test]
        public void Throw_When_commentsReplyRepository_IsNull()
        {
            // Arrange 
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleService(
                    mockedArticleRepo.Object,
                    mockedCommentsRepo.Object,
                    null,
                    mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("commentsReplyRepository"));
        }

        [Test]
        public void Throw_When_commentsRepository_IsNull()
        {
            // Arrange 
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleService(
                    mockedArticleRepo.Object,
                    null,
                    mockedCommentsReplyRepo.Object,
                    mockedUOW.Object);
            });

            Assert.That(ex.ParamName, Is.EqualTo("commentsRepository"));
        }

        [Test]
        public void Throw_When_unitOfWork_IsNull()
        {
            // Arrange 
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();

            // Act Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                new ArticleService(
                    mockedArticleRepo.Object,
                    mockedCommentsRepo.Object,
                    mockedCommentsReplyRepo.Object,
                    null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("unitOfWork"));
        }
    }
}
