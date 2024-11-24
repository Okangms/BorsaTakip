using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class CryptoTrackingContext : DbContext
    {
        public CryptoTrackingContext(DbContextOptions<CryptoTrackingContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Coin> CryptoAssets { get; set; }
        public DbSet<UserPortfolio> UserPortfolio { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
