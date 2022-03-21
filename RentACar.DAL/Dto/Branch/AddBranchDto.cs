using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.Branch
{
   public class AddBranchDto : IDto
    {
        public string BranchName { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
