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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id); // Id'yi PrimaryKey belirledim
            builder.Property(p => p.Id).ValueGeneratedOnAdd(); // Birinin aldığı Idyi başkasına verme dedik.
            builder.Property(p => p.CustomerName).IsRequired().HasMaxLength(20);
            //     (Boş bırakılamaz dedik.).(Maksımum karakter uzunluğunu verdik)
            builder.Property(p => p.CustomerSurname).IsRequired().HasMaxLength(20);
            builder.Property(p => p.CustomerPhoneNumber).IsRequired().HasMaxLength(10);
            //Entity kısmında numaraya int yerine string yazılma sebebi stringlerde uzunluk belirtilebiliyorken intlerde belirtilmemesi.
        }
    }
}
