using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace KnowledgeBase.Shared.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public string Version { get; set; }

        [Required]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FileName { get; set; }
        public string Url => Path.Combine("Storage", "Documentation", FileName);

        [Required]
        public Guid CategoryId
        {
            get { return Guid.TryParse(CategoryIdAsString, out Guid g) ? g : default; }
            set { CategoryIdAsString = Convert.ToString(value); }
        }
        public string CategoryIdAsString { get; set; }
        public Category Category { get; set; }
        
        public Guid UserProfileDetailId { get; set; }
        public UserProfileDetail UserProfileDetail { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}