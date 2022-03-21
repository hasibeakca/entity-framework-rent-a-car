using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.BranchCustomer;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class BranchCustomerService : IBranchCustomerService
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public BranchCustomerService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<int> AddBranchCustomer(AddBranchCustomerDto addBranchCustomerDto)
        {
            var addingBranchCustomer = new BranchCustomer
            {
                BranchId = addBranchCustomerDto.BranchId,
                CustomerId = addBranchCustomerDto.CustomerId
            };
            await _rentACarDbContext.BranchCustomers.AddAsync(addingBranchCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }


        public async Task<int> DeleteBranchCustomer(int BranchCustomerId)
        {
            var currentBranchCustomer = await _rentACarDbContext.BranchCustomers.
                Where(p => !p.IsDeleted && p.Id == BranchCustomerId).FirstOrDefaultAsync();
            if (currentBranchCustomer == null)
            {
                return -1;
            }
            currentBranchCustomer.IsDeleted = true;
            _rentACarDbContext.BranchCustomers.Update(currentBranchCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListBranchCustomerDto>> GetAllBranchCustomers()
        {
            return await _rentACarDbContext.BranchCustomers.Include(p => p.BranchFK).
                Include(p => p.CustomerFK).Where(p => !p.IsDeleted)
                .Select(p => new GetListBranchCustomerDto
            {
                Id = p.Id,
                BranchId = p.BranchFK.Id,
                BranchName = p.BranchFK.BranchName,
                CustomerId = p.CustomerFK.Id,
                CustomerName = p.CustomerFK.CustomerName,
                CustomerPhoneNumber = p.CustomerFK.CustomerPhoneNumber


            }).ToListAsync();
        }

        public async Task<GetBranchCustomerDto> GetBranchCustomerById(int BranchCustomerId)
        {
            return await _rentACarDbContext.BranchCustomers.Include(p => p.BranchFK)
                .Include(p => p.CustomerFK).Where(p => !p.IsDeleted && p.Id == BranchCustomerId).
                Select(p => new GetBranchCustomerDto
            {
                Id = p.Id,
                BranchId = p.BranchId,
                BranchName = p.BranchFK.BranchName,
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerFK.CustomerName,
                CustomerSurname = p.CustomerFK.CustomerSurname,
                CustomerPhoneNumber = p.CustomerFK.CustomerPhoneNumber

            }).FirstOrDefaultAsync();
        }



        public async Task<int> UpdateBranchCustomer(UpdateBranchCustomerDto updateBranchCustomerDto)
        {
            var currentBranchCustomer = await _rentACarDbContext.BranchCustomers.
            Where(p => !p.IsDeleted && p.Id == updateBranchCustomerDto.Id).FirstOrDefaultAsync();
            if (currentBranchCustomer == null)
            {
                return -1;
            }
            currentBranchCustomer.BranchId = updateBranchCustomerDto.BranchId;
            currentBranchCustomer.CustomerId = updateBranchCustomerDto.CustomerId;

            _rentACarDbContext.BranchCustomers.Update(currentBranchCustomer);
            return await _rentACarDbContext.SaveChangesAsync();


        }
    }
}
