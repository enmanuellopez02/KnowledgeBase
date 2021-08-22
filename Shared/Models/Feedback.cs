using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Shared.Models
{
    public class Feedback : Entity
    {
        [Required]
        public string Helpful { get; set; }

        [Required]
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }

        public Article Article { get; set; }
        public Guid ArticleId { get; set; }

        public UserProfileDetail UserProfileDetail { get; set; }
        public Guid UserProfileDetailId { get; set; }
    }
} 
