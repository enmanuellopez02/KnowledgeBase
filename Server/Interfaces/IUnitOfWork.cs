using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<UserProfileDetail> UserProfiles { get; }
        IRepository<Article> Articles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Feedback> Feedbacks { get; }
        Task CommitChangesAsync();
    }
}
