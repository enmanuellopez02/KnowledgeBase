using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Server.Models;
using KnowledgeBase.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Server.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly ApplicationDbContext _context;

        public SqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public Task RemoveAsync(Guid id)
        {
            var entity = new T() { Id = id };

            _context.Entry(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
