using RentACar.DAL.Dto.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
public    interface ICarService
    {
        Task<List<GetListCarDto>> GetAllCars();

        Task<GetCarDto> GetCarById(int CarId);

        Task<int> AddCar(AddCarDto addCarDto);
        Task<int> UpdateCar(UpdateCarDto updateCarDto);

        Task<int> DeleteCar(int CarId);
    }
}
