using System;
using System.Security.Claims;

namespace KnowledgeBase.Server.Models
{
    public class IdentityOptions
    {
        public ClaimsPrincipal User { get; set; }
        public Guid UserId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        public string FirstName => User.FindFirst(ClaimTypes.GivenName)?.Value;
        public string LastName => User.FindFirst(ClaimTypes.Surname)?.Value;
        public string Email => User.FindFirst("emails")?.Value;
        public string Country => User.FindFirst("country")?.Value;
        public string City => User.FindFirst("city")?.Value;

        // TODO: Other identity properties
    }
}