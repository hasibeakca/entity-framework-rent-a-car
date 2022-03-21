using RentACar.DAL.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
   public interface ICustomerService
    {
        Task<List<GetListCustomerDto>> GetAllCustomers();

        Task<GetCustomerDto> GetCustomerById(int CustomerId);

        Task<int> AddCustomer(AddCustomerDto addCustomerDto);
        Task<int> UpdateCustomer(UpdateCustomerDto updateCustomerDto);

        Task<int> DeleteCustomer(int CustomerId);
    }
}
