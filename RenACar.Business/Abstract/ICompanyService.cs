using RentACar.DAL.Dto.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
  public  interface ICompanyService
    {
        Task<List<GetListCompanyDto>> GetAllCompanies();

        Task<GetCompanyDto> GetCompanyById(int CompanyId);

        Task<int> AddCompany(AddCompanyDto addCompanyDto);
        Task<int> UpdateCompany(UpdateCompanyDto updateCompanyDto);

        Task<int> DeleteCompany(int CompanyId);
    }
}
