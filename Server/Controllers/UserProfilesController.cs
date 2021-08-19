using System.Threading.Tasks;
using KnowledgeBase.Server.DTOs.UserProfile;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserProfile))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<UserProfile>> Get()
        {
            var userProfile = await _userProfileService.GetProfileByUserIdAsync();

            if (userProfile == null)
                return NotFound();

            return userProfile;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserProfile))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserProfile>> Post(CreateUserProfileDto createUserProfileDto)
        {
            var newEserProfile = new UserProfile
            {
                IsAdmin = createUserProfileDto.IsAdmin
            };

            return await _userProfileService.CreateUserProfileAsync(newEserProfile);
        }
    }
}
