// DataAccess/Context/CryptoDbContext.cs
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<FavoriteCrypto> FavoriteCryptos { get; set; }


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

            // Quantity alanı için hassasiyet belirtin
            modelBuilder.Entity<PortfolioItem>()
        .Property(p => p.Quantity)
        .HasColumnType("decimal(18,6)");
        }
    }
}
