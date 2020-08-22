using Common.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles();

        Article GetArticle(int id);
    }
}
