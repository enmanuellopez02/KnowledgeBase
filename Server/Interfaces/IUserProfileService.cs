using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDetail> CreateUserProfileAsync();
        Task<UserProfileDetail> GetProfileByUserIdAsync();
    }
}
