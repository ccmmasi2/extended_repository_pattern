using Microsoft.EntityFrameworkCore;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.Core.Context
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductDTO> Products { get; set; }
    }
}
