using System;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IdentityOptions identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dashboard> GetDashboardAdminAsync()
        {
            var InProgress = await _unitOfWork.Articles.GetAllAsync(article => article.Status == "In Progress");
            var Pending = await _unitOfWork.Articles.GetAllAsync(article => article.Status.Contains("Submit for review"));
            var Resumit = await _unitOfWork.Articles.GetAllAsync(article => article.Status == "Resumited");
            var Published = await _unitOfWork.Articles.GetAllAsync(article => article.Status == "Published");
            var Unpublished = await _unitOfWork.Articles.GetAllAsync(article => article.Status == "Unpublished");
            var Feedback = await _unitOfWork.Feedbacks.GetAllAsync();

            var dashboard = new Dashboard
            {
                InProgress = InProgress.Count,
                Pending = Pending.Count,
                Resumit = Resumit.Count,
                Published = Published.Count,
                Unpublished = Unpublished.Count,
                Feedback = Feedback.Count
            };

            return dashboard;
        }

        public async Task<Dashboard> GetDashboardUserAsync()
        {
            var InProgress = await _unitOfWork.Articles.GetAllAsync(article => article.UserProfileDetailId == _identity.UserId && article.Status == "In Progress");
            var Pending = await _unitOfWork.Articles.GetAllAsync(article => article.UserProfileDetailId == _identity.UserId && article.Status.Contains("Submit for review"));
            var Resumit = await _unitOfWork.Articles.GetAllAsync(article => article.UserProfileDetailId == _identity.UserId && article.Status == "Resumited");
            var Published = await _unitOfWork.Articles.GetAllAsync(article => article.UserProfileDetailId == _identity.UserId && article.Status == "Published");
            var Unpublished = await _unitOfWork.Articles.GetAllAsync(article => article.UserProfileDetailId == _identity.UserId && article.Status == "Unpublished");
            var Feedback = await _unitOfWork.Feedbacks.GetAllAsync(feedback => feedback.UserProfileDetailId == _identity.UserId);

            var dashboard = new Dashboard
            {
                InProgress = InProgress.Count,
                Pending = Pending.Count,
                Resumit = Resumit.Count,
                Published = Published.Count,
                Unpublished = Unpublished.Count,
                Feedback = Feedback.Count
            };

            return dashboard;
        }
    }
}
