using System;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;

namespace KnowledgeBase.Server.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IdentityOptions identity, IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile)
        {
            userProfile.FirstName = _identity.FirstName;
            userProfile.LastName = _identity.LastName;
            userProfile.Email = _identity.Email;
            userProfile.Country = _identity.Country;
            userProfile.City = _identity.City;
            userProfile.UserId = _identity.UserId;
            userProfile.CreateSince = DateTime.UtcNow;
            
            await _unitOfWork.UserProfiles.CreateAsync(userProfile);
            await _unitOfWork.CommitChangesAsync();

            return userProfile;
        }

        public async Task<UserProfile> GetProfileByUserIdAsync()
        {
            return await _unitOfWork.UserProfiles.GetAsync(user => user.UserId == _identity.UserId);
        }
    }
}