using System.Threading.Tasks;
using KnowledgeBase.Server.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<UserProfile> UserProfiles { get; }
        Task CommitChangesAsync();
    }
}
