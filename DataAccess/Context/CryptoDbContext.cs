// DataAccess/Context/CryptoDbContext.cs
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Portfolios)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Portfolio>()
                .HasMany(p => p.Items)
                .WithOne(i => i.Portfolio)
                .HasForeignKey(i => i.PortfolioId);
        }
    }
}
