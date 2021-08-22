using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedbackAsync(Feedback feedback);
        Task<List<Feedback>> GetAllFeedbacksAsync();
        Task<List<Feedback>> GetAllFeedbacksAsync(Func<Feedback, bool> filter);
        Task<Feedback> GetFeedbackByIdAsync(Guid id);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(Guid id);
    }
}
