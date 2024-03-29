﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Configuration
{
    public class CarCustomerConfiguration : IEntityTypeConfiguration<CarCustomer>
    {
        public void Configure(EntityTypeBuilder<CarCustomer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CarId).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();

            builder.HasOne(p => p.CarFK).WithMany(p => p.CarCustomers).HasForeignKey(p => p.CarId);
            builder.HasOne(p => p.CustomerFK).WithMany(p => p.CarCustomers).HasForeignKey(p => p.CustomerId);
        }
    }
}
