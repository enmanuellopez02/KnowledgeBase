using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(Article article);
        Task<List<Article>> GetAllArticleAsync();
        Task<List<Article>> GetAllArticleAsync(Func<Article, bool> filter);
        Task<Article> GetArticleByIdAsync(Guid id);
        Task UpdateArticleAsync(Article article);
        Task DeleteArticleAsync(Guid id);
    }
}
