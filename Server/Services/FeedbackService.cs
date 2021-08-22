using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IdentityOptions identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public Task<Feedback> CreateFeedbackAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFeedbackAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetAllFeedbacksAsync(Func<Feedback, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetFeedbackByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFeedbackAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
