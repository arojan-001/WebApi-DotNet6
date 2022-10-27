using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class DataCotext : DbContext
    {
        public DataCotext(DbContextOptions<DataCotext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
