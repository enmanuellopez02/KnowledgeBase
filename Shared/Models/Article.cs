using System;
using System.Collections.Generic;
using System.IO;
using KnowledgeBase.Shared.Enums;

namespace KnowledgeBase.Shared.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Version { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FileName { get; set; }
        public string Url => Path.Combine("Storage", "Documentation", FileName);

        public Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        
        public UserProfileDetail UserProfileDetail { get; set; }
        public Guid UserProfileDetailId { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}