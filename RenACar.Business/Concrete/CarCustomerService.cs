using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.CarCustomer;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarCustomerService : ICarCustomerService
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public CarCustomerService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<int> AddCarCustomer(AddCarCustomerDto addCarCustomerDto)
        {
            var addingCarCustomer = new CarCustomer
            {
                CarId = addCarCustomerDto.CarId,
                CustomerId = addCarCustomerDto.CustomerId
            };
            await _rentACarDbContext.CarCustomers.AddAsync(addingCarCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCarCustomer(int CarCustomerId)
        {
            var currentCarCustomer = await _rentACarDbContext.CarCustomers.
                Where(p => !p.IsDeleted && p.Id == CarCustomerId).FirstOrDefaultAsync();
            if (currentCarCustomer == null)
            {
                return -1;
            }
            currentCarCustomer.IsDeleted = true;
            _rentACarDbContext.CarCustomers.Update(currentCarCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListCarCustomerDto>> GetAllCarCustomers()
        {
            return await _rentACarDbContext.CarCustomers.Include(p => p.CarFK).Include(p => p.CustomerFK)
                .Where(p => !p.IsDeleted).Select(p => new GetListCarCustomerDto
                {
                    Id = p.Id,
                    CarId = p.CarId,
                    CarName = p.CarFK.CarName,
                    CustomerId = p.CustomerId,
                    CustomerName = p.CustomerFK.CustomerName
                }).ToListAsync();
        }



        public async Task<GetCarCustomerDto> GetCarCustomerById(int CarCustomerId)
        {
            return await _rentACarDbContext.CarCustomers.Include(p => p.CarFK).
                Include(p => p.CustomerFK).Where(p => !p.IsDeleted && p.Id == CarCustomerId)
                .Select(p => new GetCarCustomerDto
                {
                    Id = p.Id,
                    CarId = p.CarId,
                    CarName = p.CarFK.CarName,
                    CustomerId = p.CustomerId,
                    CustomerName = p.CustomerFK.CustomerName

                }).FirstOrDefaultAsync();
        }


        public async Task<int> UpdateCarCustomer(UpdateCarCustomerDto updateCarCustomerDto)
        {
            var currentCarCustomer = await _rentACarDbContext.CarCustomers.
                Where(p => !p.IsDeleted && p.Id == updateCarCustomerDto.Id).
                FirstOrDefaultAsync();
            if (currentCarCustomer == null)
            {
                return -1;
            }
            currentCarCustomer.CarId = updateCarCustomerDto.CarId;
            currentCarCustomer.CustomerId = updateCarCustomerDto.CustomerId;
            _rentACarDbContext.CarCustomers.Update(currentCarCustomer);
            return await _rentACarDbContext.SaveChangesAsync();

        }
    }
}
