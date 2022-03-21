using AppCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DAL.Dto.Company
{
    public class AddCompanyDto : IDto
    {
        public string CompanyName { get; set; }
    }
}
