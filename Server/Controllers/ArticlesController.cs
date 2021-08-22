using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;
        
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Article>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("search")]
        public async Task<ActionResult<List<Article>>> Get(string status)
        {
            return await _articleService.GetAllArticleAsync(article => article.Status == status);
        }
    }
}