using System.Security.Claims;

namespace KnowledgeBase.Server.Models
{
    public class IdentityOptions
    {
        public ClaimsPrincipal User { get; set; }
        public string UserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public string FirstName => User.FindFirst(ClaimTypes.GivenName)?.Value;
        public string LastName => User.FindFirst(ClaimTypes.Surname)?.Value;
        public string Email => User.FindFirst(ClaimTypes.Email)?.Value;
        public string Country => User.FindFirst(ClaimTypes.Country)?.Value;
        public string City => User.FindFirst("city")?.Value;

        // TODO: Other identity properties
    }
}