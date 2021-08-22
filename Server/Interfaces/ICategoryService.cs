using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetAllCategoriesAsync(Func<Category, bool> filter);
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}
