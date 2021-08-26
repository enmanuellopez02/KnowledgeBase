using System.Threading.Tasks;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Interfaces
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardUserAsync();
        Task<Dashboard> GetDashboardAdminAsync();
    }
}
