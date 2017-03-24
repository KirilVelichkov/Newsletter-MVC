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
    public class AddCommentToArticle_Should
    {
        [Test]
        public void Call_commentsRepository_Add_Method_Once()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new ArticleService(
                mockedArticleRepo.Object,
                mockedCommentsRepo.Object,
                mockedCommentsReplyRepo.Object,
                () => mockedUOW.Object
                );

            var commentToAdd = new Comment();

            mockedCommentsRepo.Setup(x => x.Add(It.IsAny<Comment>()));

            // Act
            service.AddCommentToArticle(commentToAdd);

            // Assert
            mockedCommentsRepo.Verify(x => x.Add(It.IsAny<Comment>()), Times.Once);
        }
    
        [Test]
        public void Call_unitOfWork_Commit_Method_Once()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCommentsRepo = new Mock<IEfMappingRepository<Comment>>();
            var mockedCommentsReplyRepo = new Mock<IEfMappingRepository<CommentReply>>();
            var mockedUOW = new Mock<IUnitOfWork>();

            var service = new ArticleService(
                mockedArticleRepo.Object,
                mockedCommentsRepo.Object,
                mockedCommentsReplyRepo.Object,
                () => mockedUOW.Object
                );

            var commentToAdd = new Comment();

            mockedCommentsRepo.Setup(x => x.Add(It.IsAny<Comment>()));

            // Act
            service.AddCommentToArticle(commentToAdd);

            // Assert
            mockedUOW.Verify(x => x.Commit(), Times.Once);
        }
    }
}
