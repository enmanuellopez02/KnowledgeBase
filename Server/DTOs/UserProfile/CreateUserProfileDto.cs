namespace KnowledgeBase.Server.DTOs.UserProfile
{
    public record CreateUserProfileDto
    {
        public bool IsAdmin { get; init; }
    }
}
