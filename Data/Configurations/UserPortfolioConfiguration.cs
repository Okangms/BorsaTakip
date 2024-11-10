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
            builder.HasKey(up => up.Portfolio_id);
            builder.Property(up => up.Portfolio_id).ValueGeneratedOnAdd();

            builder.Property(up=>up.Amount).IsRequired().HasColumnType("decimal(18,8)");

            builder.HasOne(up => up.Users).WithMany(u => u.Portfolios).HasForeignKey(up => up.User_id);

            builder.HasOne(up => up.CryptoAsset).WithMany(ca => ca.Portfolios).HasForeignKey(up => up.Crypto_id);
        }

    }
}
