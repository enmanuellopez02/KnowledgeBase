using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KnowledgeBase.Shared.Models
{
    public class UserProfileDetail : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateSince { get; set; }

        [JsonIgnore]
        public List<Article> Articles { get; set; }

        [JsonIgnore]
        public List<Feedback> Feedbacks { get; set; }
    }
}