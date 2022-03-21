using RentACar.DAL.Dto.CarCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarCustomerService
    {
        Task<List<GetListCarCustomerDto>> GetAllCarCustomers();

        Task<GetCarCustomerDto> GetCarCustomerById(int CarCustomerId);

        Task<int> AddCarCustomer(AddCarCustomerDto addCarCustomerDto);
        Task<int> UpdateCarCustomer(UpdateCarCustomerDto updateCarCustomerDto);

        Task<int> DeleteCarCustomer(int CarCustomerId);
    }
}
