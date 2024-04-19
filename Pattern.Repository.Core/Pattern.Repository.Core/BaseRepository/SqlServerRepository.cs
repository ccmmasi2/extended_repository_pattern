using Microsoft.EntityFrameworkCore;
using Pattern.Repository.Core.Context;

namespace Pattern.Repository.Core.BaseRepository
{
    public class SqlServerRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SqlServerDbContext _context;
        private readonly DbSet<T> _dbSet;

        public SqlServerRepository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
