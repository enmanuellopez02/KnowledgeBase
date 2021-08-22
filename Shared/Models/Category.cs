using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Shared.Models
{
    public class Category : Entity
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}