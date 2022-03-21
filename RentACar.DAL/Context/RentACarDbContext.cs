using Microsoft.EntityFrameworkCore;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Context
{
  public  class RentACarDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            //bu kalıp tek tek konfigürasyonları okur inceler
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-M227QJH7\\SQLEXPRESS;Database=RenACarDB;Trusted_Connection=True;");
            //Burasıda veritabanı bağlantısını sağlar
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCustomer> CarCustomers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BranchCustomer> BranchCustomers { get; set; }

    }
}
