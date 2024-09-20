using Intelliflo.Finance.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Intelliflo.Finance.Service.DBContext
{
    public class CRMDbContext : DbContext
    {
        public DbSet<TEmailReference> EmailReference { get; set; }

        public DbSet<TContact> Contact { get; set; }

        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEmailReference>().ToTable("TEmailReference");
            modelBuilder.Entity<TContact>().ToTable("TContact");
        }
    }

}
