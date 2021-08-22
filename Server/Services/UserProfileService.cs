using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Shared.Models;

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

        public async Task<UserProfileDetail> CreateUserProfileAsync()
        {
            var userProfile = new UserProfileDetail
            {
                Id = _identity.UserId,
                FirstName = _identity.FirstName,
                LastName = _identity.LastName,
                Email = _identity.Email,
                Country = _identity.Country,
                City = _identity.City,
            };
            
            await _unitOfWork.UserProfiles.CreateAsync(userProfile);
            await _unitOfWork.CommitChangesAsync();

            return userProfile;
        }

        public async Task<UserProfileDetail> GetProfileByUserIdAsync()
        {
            return await _unitOfWork.UserProfiles.GetAsync(user => user.Id == _identity.UserId);
        }
    }
}