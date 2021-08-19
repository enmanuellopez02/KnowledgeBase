using System.Security.Claims;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using Microsoft.AspNetCore.Http;

namespace KnowledgeBase.Server.Middlewares
{
    public class CustomIdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserProfileService userProfileService)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userProfile = await userProfileService.GetProfileByUserIdAsync();

                if(userProfile != null)
                {
                    var roleName = userProfile.IsAdmin ? "Admin" : "User";
                    context.User.AddIdentity(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, roleName) }));
                }
            }

            await _next(context);
        }
    }
}
