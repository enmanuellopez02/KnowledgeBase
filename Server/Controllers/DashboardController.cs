using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dashboard))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<Dashboard>> GetDashboard()
        {
            if (User.IsInRole("Admin"))
                return await _dashboardService.GetDashboardAdminAsync();
            else
                return await _dashboardService.GetDashboardUserAsync();
        }
    }
}