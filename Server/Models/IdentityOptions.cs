using System.Security.Claims;

namespace KnowledgeBase.Server.Models
{
    public class IdentityOptions
    {
        public ClaimsPrincipal User { get; set; }
        public string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        public string FirstName => User.FindFirstValue(ClaimTypes.GivenName);
        public string LastName => User.FindFirstValue(ClaimTypes.Surname);
        public string Email => User.FindFirstValue(ClaimTypes.Email);
        public string Country => User.FindFirstValue(ClaimTypes.Country);
        public string City => User.FindFirstValue("city");

        // TODO: Other identity properties
    }
}