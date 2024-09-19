using Microsoft.EntityFrameworkCore;

namespace Intelliflo.Finance.Service.Models
{
    public class CRMDbContext : DbContext
    {
        public DbSet<TEmailReference> EmailReference { get; set; }

        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEmailReference>().ToTable("TEmailReference");
        }
    }

}
