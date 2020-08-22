using Common.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();

        Article GetArticle(int id);
    }
}
