using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dto.Company;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CompanyService : ICompanyService
    {

        private readonly RentACarDbContext _rentACarDbContext;

        public CompanyService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<int> AddCompany(AddCompanyDto addCompanyDto)
        {
            var addingCompany = new Company
            {
                CompanyName = addCompanyDto.CompanyName,

            };
            await _rentACarDbContext.Companies.AddAsync(addingCompany);
            return await _rentACarDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteCompany(int CompanyId)
        {
            var currentCompany = await _rentACarDbContext.Companies.Where(p => !p.IsDeleted && p.Id == CompanyId).FirstOrDefaultAsync();
            if (currentCompany == null)
            {
                return -1;

            }
            currentCompany.IsDeleted = true;
            _rentACarDbContext.Companies.Update(currentCompany);
            return await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task<List<GetListCompanyDto>> GetAllCompanies()
        {
            return await _rentACarDbContext.Companies.Where(p => !p.IsDeleted).Select(p => new GetListCompanyDto
            {
                Id=p.Id,
                CompanyName = p.CompanyName,
             

            }).ToListAsync();
        }

        public async Task<GetCompanyDto> GetCompanyById(int CompanyId)
        {
            return await _rentACarDbContext.Companies.Where(p => !p.IsDeleted && p.Id == CompanyId).Select(p => new GetCompanyDto
            {
                Id=p.Id,
                CompanyName = p.CompanyName,


            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            var currentCompany = await _rentACarDbContext.Companies.Where(p => !p.IsDeleted && p.Id == updateCompanyDto.Id).FirstOrDefaultAsync();
            if(currentCompany== null)
            {
                return -1;

            }
            currentCompany.CompanyName = updateCompanyDto.CompanyName;
            _rentACarDbContext.Companies.Update(currentCompany);
            return await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
