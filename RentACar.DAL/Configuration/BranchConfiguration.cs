using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Configuration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.BranchName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(10);

            builder.HasOne(p => p.CompanyFK).WithMany(p => p.Branches).HasForeignKey(p => p.CompanyId);
        }
    }
}
