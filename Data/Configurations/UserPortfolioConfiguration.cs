using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserPortfolioConfiguration : IEntityTypeConfiguration<UserPortfolio>
    {
        public void Configure(EntityTypeBuilder<UserPortfolio>builder)
        {
            builder.HasKey(up => up.UpId);
            builder.Property(up => up.UpId).ValueGeneratedOnAdd();

            builder.Property(up=>up.Amount).IsRequired().HasColumnType("decimal(18,8)");

            builder.HasOne(up => up.Portfolio)
                .WithMany(p => p.UserPortfolios)
                .HasForeignKey(up => up.PortfolioId);

            builder.HasOne(up => up.Coin)
               .WithMany(c => c.UserPortfolios)
               .HasForeignKey(up => up.Id);
        }
    }
}
