using Microsoft.EntityFrameworkCore;
using Pattern.Repository.Core.BaseRepository;
using Pattern.Repository.Core.Context;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.Core.ObjectRepository
{
    public class ProductRepository : IBaseRepository<ProductDTO>
    {
        private readonly SqlServerDbContext _context;

        public ProductRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task AddAsync(ProductDTO entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDTO entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
