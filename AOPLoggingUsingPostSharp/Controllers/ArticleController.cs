using System.Collections.Generic;
using Common.Models;
using Common.Aspects;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [Log]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

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
    }
}
