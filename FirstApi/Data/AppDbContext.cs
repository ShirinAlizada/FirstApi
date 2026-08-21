

namespace FirstApi
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options), IAppDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
