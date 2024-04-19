using Microsoft.EntityFrameworkCore;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.Core.Context
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryDTO> Categories { get; set; }
    }
}
