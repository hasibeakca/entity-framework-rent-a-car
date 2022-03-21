using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.BranchCustomer
{
    public class AddBranchCustomerDto : IDto
    {
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
    }
}
