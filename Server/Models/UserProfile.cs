using System;

namespace KnowledgeBase.Server.Models
{
    public class UserProfile : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateSince { get; set; }
    }
}
