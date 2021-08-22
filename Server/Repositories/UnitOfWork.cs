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

        public IRepository<UserProfileDetail> UserProfiles
        {
            get
            {
                if(_userProfiles == null)
                    _userProfiles = new SqlRepository<UserProfileDetail>(_context);

                return _userProfiles;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (_articles == null)
                    _articles = new SqlRepository<Article>(_context);

                return _articles;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categories == null)
                    _categories = new SqlRepository<Category>(_context);

                return _categories;
            }
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                if (_feedbacks == null)
                    _feedbacks = new SqlRepository<Feedback>(_context);

                return _feedbacks;
            }
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}