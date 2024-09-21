using Intelliflo.Finance.Service.Models;
using Microsoft.EntityFrameworkCore;

public class FactfindDbContext : DbContext
{
    public FactfindDbContext(DbContextOptions<FactfindDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<TAsset> TAssets { get; set; }
    public DbSet<TLiability> TLiabilities { get; set; }
    public DbSet<TAssetCategory> TAssetCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAsset>(entity =>
        {
            entity.ToTable("TAssets");

            //entity.HasOne(d => d.AssetCategory)
            //      .WithMany(p => p.TAssets)
            //      .HasForeignKey(d => d.AssetCategoryId)
            //      .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TAssetCategory>(entity =>
        {
            entity.ToTable("TAssetCategory");
        });
    }
}
