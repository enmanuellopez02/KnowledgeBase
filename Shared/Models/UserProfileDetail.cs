using System;
using System.Collections.Generic;

namespace KnowledgeBase.Shared.Models
{
    public class UserProfileDetail
    {
        public Guid UserProfileDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateSince { get; set; }

        public List<Article> Articles { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}