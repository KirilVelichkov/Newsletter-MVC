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
    public class GetAllCategories_Should
    {
        [Test]
        public void Return_All_Categories()
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

            var categories = new List<CategoryViewModel>()
            {
                new CategoryViewModel() { Name = "c1" },
                new CategoryViewModel() { Name = "c2" },
                new CategoryViewModel() { Name = "c3" },
                new CategoryViewModel() { Name = "c4" }
            };

            mockedCategoryRepo.Setup(x => x.GetAllMapped<CategoryViewModel>())
                .Returns(categories);

            // Act
            var actual = service.GetAllCategories();

            // Assert
            Assert.AreEqual(categories.Count(), actual.Count());
        }
    }
}
