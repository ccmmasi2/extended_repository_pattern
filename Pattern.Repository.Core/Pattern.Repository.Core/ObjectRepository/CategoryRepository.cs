using Microsoft.EntityFrameworkCore;
using Pattern.Repository.Core.BaseRepository;
using Pattern.Repository.Core.Context;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.Core.ObjectRepository
{
    public class CategoryRepository : IBaseRepository<CategoryDTO>
    {
        private readonly OracleDbContext _context;

        public CategoryRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(CategoryDTO entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDTO entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
