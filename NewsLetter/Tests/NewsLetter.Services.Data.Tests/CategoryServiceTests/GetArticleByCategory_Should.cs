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

namespace NewsLetter.Services.Data.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetArticleByCategory_Should
    {
        [Test]
        public void Return_The_Correct_Article_ByCategory()
        {
            // Arrange
            var mockedArticleRepo = new Mock<IEfMappingRepository<Article>>();
            var mockedCategoryRepo = new Mock<IEfMappingRepository<Category>>();
            var mockedUOW = new Mock<Func<IUnitOfWork>>();

            var service = new CategoryService(
                mockedArticleRepo.Object,
                mockedCategoryRepo.Object,
                mockedUOW.Object
                );

            var articl1 = new Article() { Category = new Category() { Name = "c1" } };
            var articl2 = new Article() { Category = new Category() { Name = "c2" } };
            var articl3 = new Article() { Category = new Category() { Name = "c2" } };
            var articl4 = new Article() { Category = new Category() { Name = "c2" } };
            var articl5 = new Article() { Category = new Category() { Name = "c3" } };

            var articles = new List<Article>()
            {
                articl1,
                articl2,
                articl3,
                articl4,
                articl5
            };

            mockedArticleRepo.Setup(x => x.GetAllMapped<ListArticleByCategoryViewModel>(It.IsAny<Expression<Func<Article, bool>>>()))
                .Returns((Expression<Func<Article, bool>> predicate) =>
                       articles.Where(predicate.Compile())
                       .Select(x => new ListArticleByCategoryViewModel() { Category = x.Category.Name }));

            // Act
            var actual = service.GetArticleByCategory("c2");

            // Assert
            Assert.AreEqual(actual.Count(), 3);
        }
    }
}
