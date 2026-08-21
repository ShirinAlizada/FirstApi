
namespace FirstApi.Data
{
    public interface IAppDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
