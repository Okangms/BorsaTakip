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
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u=>u.UserId).ValueGeneratedOnAdd();


            builder.Property(u=>u.Username).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Username).IsUnique();


            builder.Property(u=>u.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasMany(u=>u.Portfolio)
                .WithOne(p=>p.User)
                .HasForeignKey(p=>p.UserId);
        }
    }
}
