using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IdentityOptions identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            article.UserProfileDetailId = _identity.UserId;

            await _unitOfWork.Articles.CreateAsync(article);
            await _unitOfWork.CommitChangesAsync();

            return article;
        }

        public async Task DeleteArticleAsync(Guid id)
        {
            await _unitOfWork.Articles.RemoveAsync(id);
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task<List<Article>> GetAllArticleAsync()
        {
            return await _unitOfWork.Articles.GetAllAsync();
        }

        public async Task<List<Article>> GetAllArticleAsync(Func<Article, bool> filter)
        {
            var articles = await GetAllArticleAsync();
            return articles.Where(filter).ToList();
        }

        public async Task<Article> GetArticleByIdAsync(Guid id)
        {
            return await _unitOfWork.Articles.GetAsync(id);
        }

        public async Task UpdateArticleAsync(Article article)
        {
            article.UserProfileDetailId = _identity.UserId;

            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.CommitChangesAsync();
        }
    }
}
