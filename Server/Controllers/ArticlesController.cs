using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IdentityOptions _identity;
        private readonly IArticleService _articleService;
        
        public ArticlesController(IdentityOptions identity, IArticleService articleService)
        {
            _identity = identity;
            _articleService = articleService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Article))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id); // Filtrar por usuario
            
            if (article == null)
                return NotFound();

            return article;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Article))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle(Article article)
        {
            await _articleService.CreateArticleAsync(article);
            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Article))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(Guid id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            var articleToUpdate = await _articleService.GetArticleByIdAsync(id);
            if (articleToUpdate == null)
            {
                return NotFound();
            }

            articleToUpdate.CategoryId = article.CategoryId;
            articleToUpdate.Title = article.Title;
            articleToUpdate.Body = article.Body;
            articleToUpdate.Status = article.Status;
            articleToUpdate.UpdatedAt = DateTime.UtcNow;

            await _articleService.UpdateArticleAsync(articleToUpdate);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Article>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("search")]
        public async Task<ActionResult<List<Article>>> GetArticlesBySearch(string status)
        {
            return await _articleService.GetAllArticlesAsync(article => article.Status == status && article.UserProfileDetailId == _identity.UserId);
        }
    }
}