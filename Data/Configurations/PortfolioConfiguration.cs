using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.PortfolioId);
            builder.Property(p => p.PortfolioId).ValueGeneratedOnAdd();

            builder.Property(p => p.PortfolioName).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Portfolio)
                .HasForeignKey(p => p.UserId);
        }

    }
}
