namespace KnowledgeBase.Shared.Models
{
    public class Dashboard
    {
        public int InProgress { get; set; }
        public int Pending { get; set; }
        public int Resumit { get; set; }
        public int Published { get; set; }
        public int Unpublished { get; set; }
        public int Feedback { get; set; }
    }
}
