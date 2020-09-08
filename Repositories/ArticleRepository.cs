using Common.Aspects;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    [Log]
    public class ArticleRepository : IArticleRepository
    {
        #region Class Variables

        /// <summary>
        /// Should be loaded from DB
        /// </summary>
        private static readonly IEnumerable<Article> Articles = new List<Article>
        {
            new Article
            {
                Id = 1,
                Author = "Idan Avitan",
                Name = "how AOP can make our life easy using PostSharp",
                PublishDate = new DateTime(2020, 8, 22)
            },
            new Article
            {
                Id = 2,
                Author = "James Briggs",
                Name = "New Features in Python 3.9",
                PublishDate = new DateTime(2020, 1, 13)
            },
            new Article
            {
                Id = 3,
                Author = "AWH",
                Name = "Blazor Is Worth Your Time",
                PublishDate = new DateTime(2020, 6, 30)
            },
            new Article
            {
                Id = 4,
                Author = "Richard So",
                Name = "5 Underrated Apps for Programmers You Should Use Right Now",
                PublishDate = new DateTime(2020, 7, 30)
            },
            new Article
            {
                Id = 5,
                Author = "Daan",
                Name = "7 VS Code Extensions That Make You Want To Keep Coding Forever",
                PublishDate = new DateTime(2020, 8, 13)
            }
        };

        #endregion

        #region Instance Methods

        public IEnumerable<Article> GetArticles()
        {
            return Articles.OrderByDescending(article => article.PublishDate);
        }

        public Article GetArticle(int id)
        {
            return Articles.Single(article => article.Id == id);
        }

        #endregion
    }
}
