using System.Threading.Tasks;
using KnowledgeBase.Server.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetProfileByUserIdAsync();
        Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile);
    }
}
