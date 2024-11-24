using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace DataAccess.Configurations
{
    public class CryptoAssetConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(ca => ca.Id);
            builder.Property(ca => ca.Id).ValueGeneratedOnAdd();

            builder.Property(ca => ca.Name).IsRequired().HasMaxLength(100);
            builder.Property(ca => ca.Symbol).HasMaxLength(50);

            builder.Property(ca => ca.CurrentPrice).IsRequired().HasColumnType("decimal(18,8)");

            builder.Property(ca => ca.CurrentPrice).HasColumnType("decimal(18,8)");

            builder.Property(ca => ca.MarketCap).HasColumnType("decimal(18,8)");

            builder.Property(ca => ca.TotalVolume).HasColumnType("decimal(18,8)");
        }

           
    }
}
