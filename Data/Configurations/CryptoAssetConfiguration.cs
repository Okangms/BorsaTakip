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
    public class CryptoAssetConfiguration : IEntityTypeConfiguration<CryptoAsset>
    {
        public void Configure(EntityTypeBuilder<CryptoAsset> builder)
        {
            builder.HasKey(ca => ca.Crypto_id);
            builder.Property(ca => ca.Crypto_id).ValueGeneratedOnAdd();

            builder.Property(ca=>ca.Name).IsRequired().HasMaxLength(100);
            builder.Property(ca=>ca.Symbol).HasMaxLength(0);

            builder.Property(ca => ca.CurrentPrice).IsRequired().HasColumnType("decimal(18,8)");

            builder.HasMany(ca=>ca.Portfolios).WithOne(p=>p.CryptoAsset).HasForeignKey(ca=>ca.Crypto_id);

        }




    }
}
