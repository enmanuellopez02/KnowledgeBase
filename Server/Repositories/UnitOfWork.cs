using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Server.Persistence;

namespace KnowledgeBase.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<UserProfile> _userProfiles;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<UserProfile> UserProfiles
        {
            get
            {
                if(_userProfiles == null)
                    _userProfiles = new SqlRepository<UserProfile>(_context);

                return _userProfiles;
            }
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
