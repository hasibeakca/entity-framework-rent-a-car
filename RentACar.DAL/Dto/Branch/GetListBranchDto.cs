using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.Branch
{
    public class GetListBranchDto : IDto
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchPhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
