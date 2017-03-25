using Moq;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using NewsLetter.Services.Providers.Contracts;
using NewsLetter.ViewModels.Articles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace NewsLetter.MVC.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class CreateArticle_Should
    {
        [Test]
        public void Have_HttpPost_Attribute()
        {
            // Arrange
            var method = typeof(AdminController).GetMethod("CreateArticle", new Type[] { typeof(CreateArticleViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_ValidateAntiForgeryToken_Attribute()
        {
            // Arrange
            var method = typeof(AdminController).GetMethod("CreateArticle", new Type[] { typeof(CreateArticleViewModel) });

            // Act
            var hasAttr = method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
