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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CarName).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Color).IsRequired().HasMaxLength(20);
            builder.Property(p => p.ModelName).IsRequired().HasMaxLength(30);

            builder.HasOne(p => p.BranchFK).WithMany(p => p.Cars).HasForeignKey(p => p.BranchId);
        }
    }
}
