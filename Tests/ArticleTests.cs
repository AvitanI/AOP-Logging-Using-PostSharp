using Common.Models;
using Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        public void Should_Get_All_Articles_From_Store()
        {
            #region Arrange

            var numberOfArticles = 5;
            IArticleRepository repository = new ArticleRepository();
            IArticleService service = new ArticleService(repository);
            var controller = new ArticleController(service);

            #endregion

            #region Act

            IEnumerable<Article> articles = controller.Get();

            #endregion

            #region Assert

            Assert.AreEqual(articles.Count(), numberOfArticles);

            #endregion
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_Get_Article_By_Invalid_Id_Should_Fail()
        {
            #region Arrange

            var invalidArticleId = 6;
            IArticleRepository repository = new ArticleRepository();
            IArticleService service = new ArticleService(repository);
            var controller = new ArticleController(service);

            #endregion

            #region Act

            controller.Get(invalidArticleId);

            #endregion

            // Assert by [ExpectedException] attr.
        }
    }
}
