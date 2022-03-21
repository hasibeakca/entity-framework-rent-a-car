using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.CarCustomer
{
    public class AddCarCustomerDto : IDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
