using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Persistence;
using KnowledgeBase.Shared.Models;

namespace KnowledgeBase.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<UserProfileDetail> _userProfiles;
        public IRepository<Article> _articles;
        public IRepository<Category> _categories;
        public IRepository<Feedback> _feedbacks;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<UserProfileDetail> UserProfiles => _userProfiles ??= new SqlRepository<UserProfileDetail>(_context);
        public IRepository<Article> Articles => _articles ??= new SqlRepository<Article>(_context);
        public IRepository<Category> Categories => _categories ??= new SqlRepository<Category>(_context);
        public IRepository<Feedback> Feedbacks => _feedbacks ??= new SqlRepository<Feedback>(_context);

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
