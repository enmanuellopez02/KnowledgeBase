using System;
namespace KnowledgeBase.Shared.Models
{
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public string Helpful { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }

        public Article Article { get; set; }
        public Guid ArticleId { get; set; }

        public UserProfileDetail UserProfileDetail { get; set; }
        public Guid UserProfileDetailId { get; set; }
    }
} 
