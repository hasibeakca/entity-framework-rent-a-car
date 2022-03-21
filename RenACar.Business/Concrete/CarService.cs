using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.Car;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly RentACarDbContext _rentACarDbContext; // Bir değişken oluşturduk. Şuan da değişkenimizin içerisi boş.

        public CarService(RentACarDbContext rentACarDbContext) //Bizim için startup da oluşturulan objeyi kullanamıyoruz.
                                                               //Bu yüzden kendi boş değişkenimize buradaki bilgileri atıyoruz.
        {
            _rentACarDbContext = rentACarDbContext;
        }




        public async Task<int> AddCar(AddCarDto addCarDto)
        {
            var addingCar = new Car
            {
                CarName = addCarDto.CarName,
                ModelName = addCarDto.ModelName,
                Color = addCarDto.Color,
                BranchId = addCarDto.BranhcId

            };
            await _rentACarDbContext.Cars.AddAsync(addingCar);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCar(int CarId)
        {
            var currentCar = await _rentACarDbContext.Cars.Where(p => !p.IsDeleted && p.Id == CarId).FirstOrDefaultAsync();
            if (currentCar == null)
            {
                return -1;
            }
            currentCar.IsDeleted = true;
            _rentACarDbContext.Cars.Update(currentCar);
            return await _rentACarDbContext.SaveChangesAsync();

        }

        public async Task<List<GetListCarDto>> GetAllCars()
        {
            return await _rentACarDbContext.Cars.Include(p => p.BranchFK).Where(p => !p.IsDeleted).Select(p => new GetListCarDto
            {
                Id=p.Id,
                CarName=p.CarName,
                Color=p.Color,
                ModelName=p.ModelName,
                BranchName = p.BranchFK.BranchName


            }).ToListAsync();
        }

        public async Task<GetCarDto> GetCarById(int CarId)
        {
            return await _rentACarDbContext.Cars.Include(p => p.BranchFK).Where(p => !p.IsDeleted && p.Id == CarId).Select(p => new GetCarDto
            {
                Id=p.Id,
                CarName = p.CarName,
                Color = p.Color,
                ModelName = p.ModelName,
                BranchName = p.BranchFK.BranchName
            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCar(UpdateCarDto updateCarDto)
        {
            var currentCar = await _rentACarDbContext.Cars.Where(p => !p.IsDeleted && p.Id == updateCarDto.Id).FirstOrDefaultAsync();
            if (currentCar == null)
            {
                return -1;
            }
            currentCar.ModelName = updateCarDto.ModelName;
            currentCar.CarName = updateCarDto.CarName;
            currentCar.Color = updateCarDto.Color;
            currentCar.BranchId = updateCarDto.BranhcId;

            _rentACarDbContext.Cars.Update(currentCar);
            return await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
