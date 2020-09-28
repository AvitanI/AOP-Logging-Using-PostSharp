using Common.Aspects;
using Common.Models;
using System.Collections.Generic;
using Repositories;
using System;

namespace Services
{
    [Log]
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _repository.GetArticles();
        }

        public Article GetArticle(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The Id should be greater than 0", nameof(id));
            }

            return _repository.GetArticle(id);
        }
    }
}
