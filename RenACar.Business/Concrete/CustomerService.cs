using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.Customer;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly RentACarDbContext _rentACarDbContext; // Bir değişken oluşturduk

        public CustomerService(RentACarDbContext rentACarDbContext) // rentACarDbContext bizim için oluşturulan nesne ancak bunu kullanamıyoruz içindeki bilgilere erişmek için de boş bir değişken oluşturarak ona atıyoruz.
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<int> AddCustomer(AddCustomerDto addCustomerDto)
        {
            var addingCustomer = new Customer
            {
                CustomerName = addCustomerDto.CustomerName,
                CustomerSurname = addCustomerDto.CustomerSurname,
                CustomerPhoneNumber = addCustomerDto.CustomerPhoneNumber,


            };
            await _rentACarDbContext.Customers.AddAsync(addingCustomer);
            return await _rentACarDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteCustomer(int CustomerId)
        {
            var currentCustomer = await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == CustomerId).FirstOrDefaultAsync();
            if (currentCustomer == null)
            {
                return -1;
            }
            currentCustomer.IsDeleted = true;
            _rentACarDbContext.Customers.Update(currentCustomer);
            return await _rentACarDbContext.SaveChangesAsync();

        }

        public async Task<List<GetListCustomerDto>> GetAllCustomers()
        {
            return await _rentACarDbContext.Customers.Where(p => !p.IsDeleted).Select(p => new GetListCustomerDto
            {
                Id=p.Id,
                CustomerName= p.CustomerName,
                CustomerSurname=p.CustomerSurname,
                CustomerPhoneNumber= p.CustomerPhoneNumber
               
            }).ToListAsync();
        }

        public async Task<GetCustomerDto> GetCustomerById(int CustomerId)
        {
            return await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == CustomerId).Select(p => new GetCustomerDto
            {
                Id=p.Id,
                CustomerName = p.CustomerName,
                CustomerSurname = p.CustomerSurname,
                CustomerPhoneNumber = p.CustomerPhoneNumber
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var currentCustomer = await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == updateCustomerDto.Id).FirstOrDefaultAsync();
            if(currentCustomer== null)
            {
                return -1;
            }
            currentCustomer.CustomerName = updateCustomerDto.CustomerName;
            _rentACarDbContext.Customers.Update(currentCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
