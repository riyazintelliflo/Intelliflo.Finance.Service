using Microsoft.EntityFrameworkCore;

public class FactfindDbContext : DbContext
{
    public FactfindDbContext(DbContextOptions<FactfindDbContext> options)
        : base(options)
    {
    }

    public DbSet<TAssets> TAssets { get; set; }
    public DbSet<TLiabilities> TLiabilities { get; set; }
}
