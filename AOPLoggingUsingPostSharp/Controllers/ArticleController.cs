using System.Collections.Generic;
using Common.Models;
using Common.Aspects;
using Microsoft.AspNetCore.Mvc;
using Services;
using Repositories;

namespace AOPLoggingUsingPostSharp.Controllers
{
    [Log]
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        #region Instance Variables

        private readonly IArticleService _service;

        #endregion

        #region Constructors

        public ArticleController()
        {
            // Init here instead of 'DI' for demo purpose
            _service = new ArticleService(new ArticleRepository());
        }

        #endregion

        #region Instance Methods

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _service.GetArticles();
        }

        [Route("{id}")]
        [HttpGet]
        public Article Get(int id)
        {
            return _service.GetArticle(id);
        }

        #endregion
    }
}
