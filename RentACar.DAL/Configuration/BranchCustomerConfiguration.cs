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
    public class BranchCustomerConfiguration : IEntityTypeConfiguration<BranchCustomer>
    {
        public void Configure(EntityTypeBuilder<BranchCustomer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.BranchId).IsRequired();

            builder.HasOne(p => p.BranchFK).WithMany(p => p.BranchCustomers).HasForeignKey(p => p.BranchId);
            builder.HasOne(p => p.CustomerFK).WithMany(p => p.BranchCustomers).HasForeignKey(p => p.CustomerId);
        }
    }
}
